﻿namespace Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Lake : IEnumerable<int>
    {
        private int[] data;

        public Lake(params int[] input)
        {
            this.data = input;
        }

        public int[] Data => this.data;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.data[i];
                }
            }

            for (int i = this.data.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.data[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
           => this.GetEnumerator();
    }
}
