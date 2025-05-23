﻿using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using VaccOps.Models;
using VaccOps;

[TestFixture]
public class Tests
{
    private VaccDb vaccOps;
    Doctor d1, d2, d3, d4, d5, d6, d7, d8 ;
    Patient p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11;

    [SetUp]
    public void Setup()
    {
        this.vaccOps = new VaccDb();
        d1 = new Doctor("a", 1);
        d2 = new Doctor("b", 1);
        d3 = new Doctor("c", 1);
        p1 = new Patient("a", 1, 1, "a");
        p2 = new Patient("b", 1, 2, "b");
        p3 = new Patient("c", 1, 3, "c");

        d4 = new Doctor("d", 3);
        d5 = new Doctor("e", 4);
        d6 = new Doctor("f", 4);
        d7 = new Doctor("g", 2);
        d8 = new Doctor("h", 2);
        p4 = new Patient("d", 3, 1, "a");
        p5 = new Patient("e", 3, 1, "a");
        p6 = new Patient("f", 2, 1, "a");
        p7 = new Patient("g", 5, 10, "a");
        p8 = new Patient("h", 5, 5, "a");
        p9 = new Patient("i", 5, 50, "a");
        p10 = new Patient("j", 2, 2, "a");
        p11 = new Patient("k", 1, 2, "a");
    }

    [Test]
    public void TestAddingDoctor()
    {
        vaccOps.AddDoctor(d1);
        var d = this.vaccOps.GetDoctors().ToList();


        Assert.True(d.Count() == 1);
        Assert.True(d[0].Name == d1.Name);
        Assert.True(d[0].Popularity == d1.Popularity);
    }

    [Test]
    public void TestAddingMultipleDoctors()
    {
        for (int i = 0; i < 1000; i++)
        {
            this.vaccOps.AddDoctor(new Doctor(i.ToString(), i));
        }

        Assert.IsTrue(this.vaccOps.GetDoctors().Count() == 1000);
    }

    [Test]
    public void TestAddingDoctorAlreadyExistThrowException()
    {
        this.vaccOps.AddDoctor(d1);
        Assert.Throws<ArgumentException>(() => this.vaccOps.AddDoctor(d1));
    }

    [Test]
    public void TestAddingPatient()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddPatient(d1, p1);
        var p = this.vaccOps.GetPatients().ToList();

        Assert.True(p.Count() == 1);
        Assert.True(p[0].Name == p1.Name);
        Assert.True(p[0].Height == p1.Height);
        Assert.True(p[0].Town == p1.Town);
        Assert.True(p[0].Age == p1.Age);
    }

    [Test]
    public void TestAddingMultiplePatients()
    {
        this.vaccOps.AddDoctor(d1);
        for (int i = 0; i < 1000; i++)
        {
            var p = new Patient(i.ToString(), i, i, i.ToString());
            this.vaccOps.AddPatient(d1, p);
        }

        Assert.True(this.vaccOps.GetPatients().Count() == 1000);
    }


    [Test]
    public void TestAddingPatientWithNonExistentDoctorThrowException()
    {
        Assert.Throws<ArgumentException>(() => this.vaccOps.AddPatient(d1, p1));
    }


    [Test]
    public void TestNotAddingAnyDoctors()
    {
        Assert.True(this.vaccOps.GetDoctors().Count() == 0);
    }

    [Test]
    public void TestNotAddingAnyPatients()
    {
        Assert.True(this.vaccOps.GetPatients().Count() == 0);
    }

    [Test]
    public void TestAddingPatientAlreadyExistThrowException()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddPatient(d1, p1);
        Assert.Throws<ArgumentException>(() => this.vaccOps.AddPatient(d1, p1));
    }

    [Test]
    public void TestExistDoctorNotAdded()
    {
        Assert.False(this.vaccOps.Exist(d1));
    }

    [Test]
    public void TestExistPatientNotAdded()
    {
        Assert.False(this.vaccOps.Exist(p1));
    }

    [Test]
    public void TestExistWithAddedDoctor()
    {
        this.vaccOps.AddDoctor(d1);
        Assert.True(this.vaccOps.Exist(d1));
    }

    [Test]
    public void TestExistWithAddedPatient()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddPatient(d1, p1);
        Assert.True(this.vaccOps.Exist(p1));
    }

    [Test]
    public void TestRemoveDoc()
    {
        this.vaccOps.AddDoctor(d1);
        var d = this.vaccOps.RemoveDoctor(d1.Name);

        Assert.AreSame(d1, d);
    }

    [Test]
    public void TestRemoveDocTwice()
    {
        this.vaccOps.AddDoctor(d1);
        var d = this.vaccOps.RemoveDoctor(d1.Name);
        Assert.Throws<ArgumentException>(() => this.vaccOps.RemoveDoctor(d1.Name));
    }

    [Test]
    public void TestRemoveDocShouldRemoveItsPatients()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.AddPatient(d1, p2);
        this.vaccOps.AddPatient(d1, p3);


        this.vaccOps.RemoveDoctor(d1.Name);

        Assert.False(this.vaccOps.Exist(p1));
        Assert.False(this.vaccOps.Exist(p2));
        Assert.False(this.vaccOps.Exist(p3));

        var coll = this.vaccOps.GetDoctorsByPopularity(d1.Popularity);
        Assert.IsTrue(coll.Count() == 0);
    }

    [Test]
    public void TestRemoveDocShouldRemoveFromDocPopularity()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.RemoveDoctor(d1.Name);

        var coll = this.vaccOps.GetDoctorsByPopularity(d1.Popularity);
        Assert.IsTrue(coll.Count() == 0);
    }

    [Test]
    public void TestChangeDoctor()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);

        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.ChangeDoctor(d1, d2, p1);

        this.vaccOps.RemoveDoctor(d1.Name);

        Assert.True(this.vaccOps.Exist(p1));
    }

    [Test]
    public void TestChangeDoctorAndRemoveDocShouldRemovePatient()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);

        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.ChangeDoctor(d1, d2, p1);

        this.vaccOps.RemoveDoctor(d2.Name);

        Assert.False(this.vaccOps.Exist(p1));
    }

    [Test]
    public void TestChangeDoctorGetAllPatientsInAgeReturninEmptyColl()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);

        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.ChangeDoctor(d1, d2, p1);

        this.vaccOps.RemoveDoctor(d2.Name);

        Assert.True(this.vaccOps.GetPatientsInAgeRange(0, 10).Count() == 0);
    }

    [Test]
    public void TestGettingDocByPopularity()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);


        Assert.IsTrue(this.vaccOps.GetDoctorsByPopularity(1).Count() == 2);
    }

    [Test]
    public void TestGettingDocByPopularity1()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);
        this.vaccOps.RemoveDoctor(d1.Name);


        Assert.IsTrue(this.vaccOps.GetDoctorsByPopularity(1).Count() == 1);
    }

    [Test]
    public void TestGettingDocByPopularity2()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);
        this.vaccOps.RemoveDoctor(d1.Name);


        Assert.IsTrue(this.vaccOps.GetDoctorsByPopularity(2).Count() == 0);
    }

    [Test]
    public void TestGettingPatientsByTown()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.AddPatient(d1, p2);
        this.vaccOps.AddPatient(d1, p3);

        Assert.AreSame(this.vaccOps.GetPatientsByTown(p1.Town).ToList()[0], p1);
    }

    [Test]
    public void TestGettingPatientsByTown1()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);
        this.vaccOps.AddPatient(d2, p1);
        this.vaccOps.AddPatient(d1, p2);
        this.vaccOps.AddPatient(d1, p3);
        this.vaccOps.RemoveDoctor(d2.Name);

        Assert.IsTrue(this.vaccOps.GetPatientsByTown(p1.Town).ToList().Count == 0);
    }

    [Test]
    public void TestGetPatientsInAgeRange()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.AddPatient(d1, p2);
        this.vaccOps.AddPatient(d1, p3);

        var c = this.vaccOps.GetPatientsInAgeRange(1, 2);
        Assert.True(c.Count() == 2);
        Assert.True(c.ToList().Contains(p1));
        Assert.True(c.ToList().Contains(p2));
    }

    [Test]
    public void TestGetPatientsInAgeRange1()
    {
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);
        this.vaccOps.AddPatient(d2, p1);
        this.vaccOps.AddPatient(d1, p2);
        this.vaccOps.AddPatient(d1, p3);

        this.vaccOps.RemoveDoctor(d1.Name);

        var c = this.vaccOps.GetPatientsInAgeRange(1, 2);
        Assert.True(c.Count() == 1);
        Assert.True(c.ToList().Contains(p1));
    }

    [Test]
    public void TestGetDoctorsSortedByPatientsCountAndName()
    {
        this.vaccOps.AddDoctor(d3);
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);


        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.AddPatient(d2, p2);
        this.vaccOps.AddPatient(d2, p3);

        var c = this.vaccOps.GetDoctorsSortedByPatientsCountDescAndNameAsc().ToList();
        Assert.AreSame(c[0], d2);
        Assert.AreSame(c[1], d1);
        Assert.AreSame(c[2], d3);
    }

    [Test]
    public void TestGetDoctorsSortedByPatientsCountAndName1()
    {
        this.vaccOps.AddDoctor(d3);
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);


        this.vaccOps.AddPatient(d1, p1);
        this.vaccOps.AddPatient(d2, p2);
        this.vaccOps.AddPatient(d2, p3);
        this.vaccOps.ChangeDoctor(d2, d3, p3);

        var c = this.vaccOps.GetDoctorsSortedByPatientsCountDescAndNameAsc().ToList();
        ;
        Assert.AreSame(c[0], d1);
        Assert.AreSame(c[1], d2);
        Assert.AreSame(c[2], d3);
    }

    [Test]
    public void TestGetDoctorsSortedByPatientsCountAndName2()
    {
        this.vaccOps.AddDoctor(d3);
        this.vaccOps.AddDoctor(d1);
        this.vaccOps.AddDoctor(d2);


        this.vaccOps.AddPatient(d3, p1);
        this.vaccOps.AddPatient(d3, p2);

        var c = this.vaccOps.GetDoctorsSortedByPatientsCountDescAndNameAsc().ToList();
        Assert.AreSame(c[0], d3);
        Assert.AreSame(c[1], d1);
        Assert.AreSame(c[2], d2);
    }

    [Test]
    public void TestGetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAgeDesc()
    {
        Doctor d4 = new Doctor("d", 3);
        Doctor d5 = new Doctor("e", 4);
        Doctor d6 = new Doctor("f", 4);

        Patient p4 = new Patient("d", 3, 1, "a");
        Patient p5 = new Patient("e", 3, 1, "a");
        Patient p6 = new Patient("f", 2, 1, "a");
        Patient p7 = new Patient("g", 5, 10, "a");
        Patient p8 = new Patient("h", 5, 5, "a");

        this.vaccOps.AddDoctor(d4);
        this.vaccOps.AddDoctor(d5);
        this.vaccOps.AddDoctor(d6);

        this.vaccOps.AddPatient(d4, p4);
        this.vaccOps.AddPatient(d5, p5);
        this.vaccOps.AddPatient(d6, p6);
        this.vaccOps.AddPatient(d6, p7);
        this.vaccOps.AddPatient(d6, p8);

        var c = this.vaccOps.GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge().ToList();
        var expected = new List<Patient>() { p4, p8, p7, p5, p6 };
        CollectionAssert.AreEqual(expected, c);
    }

    [Test]
    public void TestGetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAgeDesc2()
    {

        this.vaccOps.AddDoctor(d4);
        this.vaccOps.AddDoctor(d5);
        this.vaccOps.AddDoctor(d6);
        this.vaccOps.AddDoctor(d7);
        this.vaccOps.AddDoctor(d8);

        this.vaccOps.AddPatient(d4, p4);
        this.vaccOps.AddPatient(d5, p5);
        this.vaccOps.AddPatient(d6, p6);
        this.vaccOps.AddPatient(d6, p7);
        this.vaccOps.AddPatient(d6, p8);
        this.vaccOps.AddPatient(d7, p9);
        this.vaccOps.AddPatient(d8, p10);
        this.vaccOps.AddPatient(d8, p11);

        var c = this.vaccOps.GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge().ToList();

        var expected = new List<Patient>() { p9, p10, p11, p4, p8, p7, p5, p6 };
        CollectionAssert.AreEquivalent(expected, c);
    }

    [Test]
    public void TestAddDoctorPerf()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 10000; i++)
        {
            this.vaccOps.AddDoctor(new Doctor(i.ToString(), i));
        }

        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20000);
    }

    [Test]
    public void TestAddPatientPerf()
    {
        Stopwatch sw = new Stopwatch();
        this.vaccOps.AddDoctor(d1);
        sw.Start();

        for (int i = 0; i < 10000; i++)
        {
            this.vaccOps.AddPatient(d1, new Patient(i.ToString(), i, i, i.ToString())); ;
        }

        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestRemoveDoctorPerf()
    {
        Stopwatch sw = new Stopwatch();
        for (int i = 0; i < 10000; i++)
        {
            this.vaccOps.AddDoctor(new Doctor(i.ToString(), i));
        }

        sw.Start();
        for (int i = 0; i < 10000; i++)
        {
            this.vaccOps.RemoveDoctor(i.ToString());
        }
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestGetDoctorsByPopularityPef()
    {
        Stopwatch sw = new Stopwatch();
        for (int i = 0; i < 10000; i++)
        {
            this.vaccOps.AddDoctor(new Doctor(i.ToString(), i));
        }

        sw.Start();
        var n = this.vaccOps.GetDoctorsByPopularity(1);
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestGetPatientsByTownPef()
    {
        Stopwatch sw = new Stopwatch();
        this.vaccOps.AddDoctor(d1);

        for (int i = 0; i < 10000; i++)
        {
            this.vaccOps.AddPatient(d1, new Patient(i.ToString(), i, i, i.ToString())); ;
        }

        sw.Start();
        this.vaccOps.GetPatientsByTown("0");
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestGetDoctorsSortedByPatientsCountDescAndNameAscPef()
    {
        Stopwatch sw = new Stopwatch();
        for (int i = 0; i < 10000; i++)
        {
            this.vaccOps.AddDoctor(new Doctor(i.ToString(), i));
        }

        sw.Start();
        var n = this.vaccOps.GetDoctorsSortedByPatientsCountDescAndNameAsc();
        sw.Stop();
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }

    [Test]
    public void TestGetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAgePerf()
    {
        Stopwatch sw = new Stopwatch();

        for (int i = 0; i < 10000; i++)
        {

            var d = new Doctor(i.ToString(), i);
            this.vaccOps.AddDoctor(d);
            this.vaccOps.AddPatient(d, new Patient(i.ToString(), i, i, i.ToString())); ;
        }

        sw.Start();
        this.vaccOps.GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge();
        sw.Stop();
        var a = sw.ElapsedMilliseconds;
        Assert.IsTrue(sw.ElapsedMilliseconds <= 20);
    }
}
