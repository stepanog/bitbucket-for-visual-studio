﻿using System;
using System.IO;
using System.Linq;
using GitClientVS.Contracts.Models.GitClientModels;
using LibGit2Sharp;
using Microsoft.VisualStudio.TeamFoundation.Git.Extensibility;

namespace GitClientVS.TeamFoundation.Extensions
{
    public static class GitRepositoryExtensions
    {
        public static GitRemoteRepository ToModel(this IGitRepositoryInfo source)
        {
            if (source == null) return null;

            var dir = new DirectoryInfo(source.RepositoryPath);
            var repoPath = Repository.Discover(source.RepositoryPath);
            var repo = repoPath == null ? null : new Repository(repoPath);
            if (repo == null) return null;

            var repoUrl = repo?.Network.Remotes["origin"]?.Url;
            string repoName = null, ownerName = null;
            if (repoUrl != null)
            {
                try
                {
                    var repoUri = new Uri(repoUrl);
                    repoName = repoUri.Segments.Last().TrimEnd('/').TrimEnd(".git");
                    ownerName = repoUri.UserInfo;
                } catch (Exception)
                {
                    // probably ssh remote
                    return null;
                }
             
            }
          
            return new GitRemoteRepository(repoName, ownerName, repoUrl);
        }
    }
}