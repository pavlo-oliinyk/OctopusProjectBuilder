﻿using Octopus.Client.Model;
using Octopus.Client.Repositories;

namespace OctopusProjectBuilder.Uploader.Tests.Helpers
{
    internal class FakeUserRolesRepository : FakeNamedRepository<UserRoleResource>, IUserRolesRepository
    {
    }
}