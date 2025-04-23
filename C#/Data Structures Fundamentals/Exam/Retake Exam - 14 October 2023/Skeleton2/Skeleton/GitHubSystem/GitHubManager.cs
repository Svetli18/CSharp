using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHubSystem
{
    public class GitHubManager : IGitHubManager
    {
        private Dictionary<string, User> users;
        private Dictionary<string, Repository> repositorys;
        private Dictionary<string, Commit> commits;

        public GitHubManager()
        {
            this.users = new Dictionary<string, User>();
            this.repositorys = new Dictionary<string, Repository>();
            this.commits = new Dictionary<string, Commit>();
        }

        public void Create(User user)
        {
            if (!this.users.ContainsKey(user.Id))
            {
                this.users[user.Id] = user;
            }
        }

        public void Create(Repository repository)
        {
            if (!this.repositorys.ContainsKey(repository.Id))
            {
                this.repositorys[repository.Id] = repository;
            }
        }

        public bool Contains(User user)
        {
            return this.users.ContainsKey(user.Id);
        }

        public bool Contains(Repository repository)
        {
            return this.repositorys.ContainsKey(repository.Id);
        }

        public void CommitChanges(Commit commit)
        {
            if (!this.commits.ContainsKey(commit.Id))
            {
                throw new ArgumentException();
            }

            this.commits[commit.Id] = commit;
        }

        public Repository ForkRepository(string repositoryId, string userId)
        {
            if (!this.repositorys.ContainsKey(repositoryId) || !this.users.ContainsKey(userId))
            {
                throw new ArgumentException();
            }

            Repository repository = this.repositorys[repositoryId];

            repository.Stars = 0;

            return repository;
        }

        public IEnumerable<Commit> GetCommitsForRepository(string repositoryId)
        {
            List<Commit> result = null;

            foreach (var currentCommit in this.commits.Values)
            {
                if (currentCommit.RepositoryId.Equals(repositoryId))
                {
                    result.Add(currentCommit);
                }
            }

            return result;
        }

        public IEnumerable<Repository> GetRepositoriesByOwner(string userId)
        {
            List<Repository> result = null;

            foreach (var currentRepository in this.repositorys.Values)
            {
                if (currentRepository.OwnerId.Equals(userId))
                {
                    result.Add(currentRepository);
                }
            }

            return result;
        }

        public IEnumerable<Repository> GetMostForkedRepositories()
        {
            return null;
        }

        public IEnumerable<Repository> GetRepositoriesOrderedByCommitsInDescending()
        {
            List<Repository> result = null;

            if (0 < this.repositorys.Count)
            {
                result = new List<Repository>(this.repositorys.Values.OrderByDescending(r => r.Stars));
            }

            return result;
        }
    }
}