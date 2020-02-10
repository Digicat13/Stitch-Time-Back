﻿using StitchTime.Core.Abstractions.Repositories;

namespace StitchTime.Core.Abstractions
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IReportRepository ReportRepository { get; }

        public IProjectRepository ProjectRepository { get; }

        public ITeamMemberRepository TeamMemberRepository { get; }

        public ITeamRepository TeamRepository { get; }

        public void Save();
    }
}
