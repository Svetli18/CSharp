using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Kubernetes
{
    public class Controller : IController
    {
        SortedSet<Pod> pods = new SortedSet<Pod>();
        Dictionary<string, Pod> byId = new Dictionary<string, Pod>();
        Dictionary<string, HashSet<Pod>> byNamespace = new Dictionary<string, HashSet<Pod>>();
        OrderedDictionary<int, SortedSet<Pod>> byPort = new OrderedDictionary<int, SortedSet<Pod>>();

        public void Deploy(Pod pod)
        {
            //TODO tuk moje da iska proverka i za pod ID!!!
            if (!this.byNamespace.ContainsKey(pod.Namespace))
            {
                this.byNamespace[pod.Namespace] = new HashSet<Pod>();
            }
            if (!this.byPort.ContainsKey(pod.Port))
            {
                this.byPort[pod.Port] = new SortedSet<Pod>();
            }

            this.pods.Add(pod);
            this.byId[pod.Id] = pod;
            this.byNamespace[pod.Namespace].Add(pod);
            this.byPort[pod.Port].Add(pod);
        }

        public bool Contains(string podId)
        {
            return this.byId.ContainsKey(podId);
        }

        public int Size()
        {
            return this.byId.Count;
        }

        public Pod GetPod(string podId)
        {
            if (!this.byId.ContainsKey(podId))
            {
                throw new ArgumentException();
            }

            return this.byId[podId];
        }

        public void Uninstall(string podId)
        {
            Pod pod = this.GetPod(podId);

            this.pods.Remove(pod);
            this.byId.Remove(podId);
            this.byNamespace[pod.Namespace].Remove(pod);
            this.byPort[pod.Port].Remove(pod);

            if (this.byNamespace[pod.Namespace].Count == 0)
            {
                this.byNamespace.Remove(pod.Namespace);
            }
            if (this.byPort[pod.Port].Count == 0)
            {
                this.byPort.Remove(pod.Port);
            }
        }

        public void Upgrade(Pod pod)
        {
            if (!this.byId.ContainsKey(pod.Id))
            {
                this.Deploy(pod);
            }
            else
            {
                Pod oldPod = this.byId[pod.Id];
                this.byId.Remove(oldPod.Id);
                this.byNamespace[oldPod.Namespace].Remove(oldPod);
                this.byPort[oldPod.Port].Remove(oldPod);

                if (this.byNamespace[oldPod.Namespace].Count == 0)
                {
                    this.byNamespace.Remove(oldPod.Namespace);
                }
                if (this.byPort[oldPod.Port].Count == 0)
                {
                    this.byPort.Remove(oldPod.Port);
                }

                this.Deploy(pod);
            }
        }

        public IEnumerable<Pod> GetPodsInNamespace(string @namespace)
        {
            return this.byNamespace[@namespace];
        }

        public IEnumerable<Pod> GetPodsBetweenPort(int lowerBound, int upperBound)
        {
            return this.byPort.Range(lowerBound, true, upperBound, true).SelectMany(p => p.Value);
        }

        public IEnumerable<Pod> GetPodsOrderedByPortThenByName()
        {
            return this.byPort.OrderByDescending(p => p.Key).SelectMany(p => p.Value);
            //return pods;
            //return this.byId.Values.OrderByDescending(p => p.Port).ThenBy(p => p.Namespace);
        }
    }
}