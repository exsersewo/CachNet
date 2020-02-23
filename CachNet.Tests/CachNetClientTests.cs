using CachNet.Entities;
using CachNet.Net;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CachNet.Tests
{
    public class CachNetClientTests
    {
        [Fact]
        public async Task ClientInit()
        {
            var mock = new Mock<ICachetClient>(MockBehavior.Strict);

            mock.Setup(x => x.PingAsync())
                .Returns(Task.FromResult(new ResponseSingle<string>
                {
                    Data = "Pong!"
                }));
            mock.Setup(x => x.GetVersionAsync())
                .Returns(Task.FromResult(new ResponseVersion
                {
                    Meta = new ResponseMetaVersion
                    {
                        OnLatest = true,
                        Latest = new ResponseLatest
                        {
                            TagName = "v2.3.10",
                            Prerelease = false,
                            Draft = false
                        }
                    },
                    Data = "2.3.11-dev"
                }));

            var ping = await mock.Object.PingAsync();
            var version = await mock.Object.GetVersionAsync();

            var client = new CachetClient("https://demo.cachethq.io");

            Assert.NotNull(client);
            Assert.Equal("https://demo.cachethq.io", client.BaseUrl);

            Assert.Equal("Pong!", ping.Data);
            Assert.NotNull(ping.Data);
            Assert.Null(ping.Meta);

            Assert.Equal("2.3.11-dev", version.Data);
            Assert.NotNull(version.Data);
            Assert.NotNull(version.Meta);
        }

        [Fact]
        public async Task ComponentTests()
        {
            var timeParser = "yyyy-MM-dd HH:mm:ss";
            var allComponents = new List<Component>
            {
                new Component
                {
                    Id = 1,
                    Name = "API",
                    Description = "This is the Cachet API.",
                    Link = "",
                    Status = ComponentStatus.Operational,
                    Order = 0,
                    GroupId = 0,
                    CreatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                    DeletedAt = null,
                    StatusName = "Operational",
                    Tags = new Dictionary<string, string>
                    {
                        { "slug-of-tag", "Tag Name" }
                    }
                }
            };
            var firstComponent = new Component
            {
                Id = 1,
                Name = "API",
                Description = "This is the Cachet API.",
                Link = "",
                Status = ComponentStatus.Operational,
                Order = 0,
                GroupId = 0,
                CreatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                UpdatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                DeletedAt = null,
                StatusName = "Operational",
                Tags = new Dictionary<string, string>
                        {
                            { "slug-of-tag", "Tag Name" }
                        }
            };
            var updatedComponent = new Component
            {
                Id = 1,
                Name = "Component Name",
                Description = "Description",
                Link = "",
                Status = ComponentStatus.Operational,
                Order = 0,
                GroupId = 0,
                CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                DeletedAt = null,
                StatusName = "Operational",
                Tags = new Dictionary<string, string>
                        {
                            { "slug-of-tag", "Tag Name" }
                        }
            };

            var mock = new Mock<ICachetClient>(MockBehavior.Strict);

            mock.Setup(x => x.GetAllComponentsAsync())
                .Returns(Task.FromResult(new ResponseComponent
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Component>
                    {
                        new Component
                        {
                            Id = 1,
                            Name = "API",
                            Description = "This is the Cachet API.",
                            Link = "",
                            Status = ComponentStatus.Operational,
                            Order = 0,
                            GroupId = 0,
                            CreatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                            DeletedAt = null,
                            StatusName = "Operational",
                            Tags = new Dictionary<string, string>
                            {
                                { "slug-of-tag", "Tag Name" }
                            }
                        }
                    }
                }));

            mock.Setup(x => x.GetComponentAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResponseComponent
                {
                    Data = new List<Component>
                    {
                        new Component
                        {
                            Id = 1,
                            Name = "API",
                            Description = "This is the Cachet API.",
                            Link = "",
                            Status = ComponentStatus.Operational,
                            Order = 0,
                            GroupId = 0,
                            CreatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-07-24 14:42:10", timeParser, null),
                            DeletedAt = null,
                            StatusName = "Operational",
                            Tags = new Dictionary<string, string>
                            {
                                { "slug-of-tag", "Tag Name" }
                            }
                        }
                    }
                }));

            mock.Setup(x => x.AddComponentAsync(It.IsAny<PostComponent>()))
                .Returns(Task.FromResult(new ResponseComponent
                {
                    Data = new List<Component>
                    {
                        new Component
                        {
                            Id = 1,
                            Name = "Component Name",
                            Description = "Description",
                            Link = "",
                            Status = ComponentStatus.Operational,
                            Order = 0,
                            GroupId = 0,
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DeletedAt = null,
                            StatusName = "Operational",
                            Tags = new Dictionary<string, string>
                            {
                                { "slug-of-tag", "Tag Name" }
                            }
                        }
                    }
                }));

            mock.Setup(x => x.UpdateComponentAsync(It.IsAny<int>(), It.IsAny<PutComponent>()))
                .Returns(Task.FromResult(new ResponseComponent
                {
                    Data = new List<Component>
                    {
                        new Component
                        {
                            Id = 1,
                            Name = "Component Name",
                            Description = "Description",
                            Link = "",
                            Status = ComponentStatus.Operational,
                            Order = 0,
                            GroupId = 0,
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DeletedAt = null,
                            StatusName = "Operational",
                            Tags = new Dictionary<string, string>
                            {
                                { "slug-of-tag", "Tag Name" }
                            }
                        }
                    }
                }));

            var all = await mock.Object.GetAllComponentsAsync();
            var first = await mock.Object.GetComponentAsync(1);
            var add = await mock.Object.AddComponentAsync(new PostComponent
            {
                Name = "Component Name",
                Status = ComponentStatus.Operational
            });
            var put = await mock.Object.UpdateComponentAsync(1, 
                new PutComponent
            {
                Name = "Component Name",
                Status = ComponentStatus.Operational
            });

            var client = new CachetClient("https://demo.cachethq.io");

            Assert.Equal(allComponents[0].Name, all.Data[0].Name);
            Assert.Equal(firstComponent.Name, first.Data[0].Name);
            Assert.Equal(updatedComponent.Name, add.Data[0].Name);
            Assert.Equal(updatedComponent.Name, put.Data[0].Name);
        }

        [Fact]
        public async Task ComponentGroupTests()
        {
            var timeParser = "yyyy-MM-dd HH:mm:ss";
            var allGroups = new List<ComponentGroup>
            {
                new ComponentGroup
                {
                    Id = 1,
                    Name = "Websites",
                    Order = 0,
                    Collapsed = Collapsable.No,
                    CreatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
                }
            };
            var firstGroup = new ComponentGroup
            {
                Id = 1,
                Name = "Websites",
                Order = 0,
                Collapsed = Collapsable.No,
                CreatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
                UpdatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
            };
            var newGroup = new ComponentGroup
            {
                Id = 2,
                Name = "Foo",
                Order = 1,
                Collapsed = Collapsable.No,
                CreatedAt = DateTime.ParseExact("2015-11-07 16:35:13", timeParser, null),
                UpdatedAt = DateTime.ParseExact("2015-11-07 16:35:13", timeParser, null),
            };

            var mock = new Mock<ICachetClient>(MockBehavior.Strict);

            mock.Setup(x => x.GetAllComponentGroupsAsync())
                .Returns(Task.FromResult(new ResponseComponentGroup
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<ComponentGroup>
                    {
                        new ComponentGroup
                        {
                            Id = 1,
                            Name = "Websites",
                            Order = 0,
                            Collapsed = Collapsable.No,
                            CreatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
                        }
                    }
                }));

            mock.Setup(x => x.GetComponentGroupAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResponseComponentGroup
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<ComponentGroup>
                    {
                        new ComponentGroup
                        {
                            Id = 1,
                            Name = "Websites",
                            Order = 0,
                            Collapsed = Collapsable.No,
                            CreatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-11-07 13:30:04", timeParser, null),
                        }
                    }
                }));

            mock.Setup(x => x.AddComponentGroupAsync(It.IsAny<PostComponentGroup>()))
                .Returns(Task.FromResult(new ResponseComponentGroup
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<ComponentGroup>
                    {
                        new ComponentGroup
                        {
                            Id = 2,
                            Name = "Foo",
                            Order = 1,
                            Collapsed = Collapsable.No,
                            CreatedAt = DateTime.ParseExact("2015-11-07 16:35:13", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-11-07 16:35:13", timeParser, null),
                        }
                    }
                }));

            mock.Setup(x => x.UpdateComponentGroupAsync(It.IsAny<int>(), It.IsAny<PostComponentGroup>()))
                .Returns(Task.FromResult(new ResponseComponentGroup
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<ComponentGroup>
                    {
                        new ComponentGroup
                        {
                            Id = 2,
                            Name = "Foo",
                            Order = 1,
                            Collapsed = Collapsable.No,
                            CreatedAt = DateTime.ParseExact("2015-11-07 16:35:13", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-11-07 16:35:13", timeParser, null),
                        }
                    }
                }));

            var all = await mock.Object.GetAllComponentGroupsAsync();
            var first = await mock.Object.GetComponentGroupAsync(1);
            var add = await mock.Object.AddComponentGroupAsync(new PostComponentGroup
            {
                Name = "Component Name",
                Order = 0,
                Collapsed = Collapsable.No
            });
            var put = await mock.Object.UpdateComponentGroupAsync(1,
                new PostComponentGroup
                {
                    Name = "Component Name",
                    Order = 0,
                    Collapsed = Collapsable.No
                });

            var client = new CachetClient("https://demo.cachethq.io");

            Assert.Equal(allGroups[0].Name, all.Data[0].Name);
            Assert.Equal(firstGroup.Name, first.Data[0].Name);
            Assert.Equal(newGroup.Name, add.Data[0].Name);
            Assert.Equal(newGroup.Name, put.Data[0].Name);
        }

        [Fact]
        public async Task IncidentTests()
        {
            var timeParser = "yyyy-MM-dd HH:mm:ss";

            var allIncidents = new List<Incident>
            {
                new Incident
                {
                    Id = 1,
                    ComponentId = 0,
                    Name = "Incident Name",
                    Status = IncidentStatus.Fixed,
                    Visible = 1,
                    Message = "Incident Message",
                    ScheduledAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                    CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                    DeletedAt = null,
                    HumanStatus = "Fixed"
                }
            };
            var firstIncident = new Incident
            {
                Id = 1,
                ComponentId = 0,
                Name = "Incident Name",
                Status = IncidentStatus.Fixed,
                Visible = 1,
                Message = "Incident Message",
                ScheduledAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                DeletedAt = null,
                HumanStatus = "Fixed"
            };

            var mock = new Mock<ICachetClient>(MockBehavior.Strict);

            mock.Setup(x => x.GetAllIncidentsAsync())
                .Returns(Task.FromResult(new ResponseIncident
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Incident>
                    {
                        new Incident
                        {
                            Id = 1,
                            ComponentId = 0,
                            Name = "Incident Name",
                            Status = IncidentStatus.Fixed,
                            Visible = 1,
                            Message = "Incident Message",
                            ScheduledAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DeletedAt = null,
                            HumanStatus = "Fixed"
                        }
                    }
                }));

            mock.Setup(x => x.GetIncidentAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResponseIncident
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Incident>
                    {
                        new Incident
                        {
                            Id = 1,
                            ComponentId = 0,
                            Name = "Incident Name",
                            Status = IncidentStatus.Fixed,
                            Visible = 1,
                            Message = "Incident Message",
                            ScheduledAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DeletedAt = null,
                            HumanStatus = "Fixed"
                        }
                    }
                }));

            mock.Setup(x => x.AddIncidentAsync(It.IsAny<PostIncident>()))
                .Returns(Task.FromResult(new ResponseIncident
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Incident>
                    {
                        new Incident
                        {
                            Id = 1,
                            ComponentId = 0,
                            Name = "Incident Name",
                            Status = IncidentStatus.Fixed,
                            Visible = 1,
                            Message = "Incident Message",
                            ScheduledAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DeletedAt = null,
                            HumanStatus = "Fixed"
                        }
                    }
                }));

            mock.Setup(x => x.UpdateIncidentAsync(It.IsAny<int>(), It.IsAny<PutIncident>()))
                .Returns(Task.FromResult(new ResponseIncident
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Incident>
                    {
                        new Incident
                        {
                            Id = 1,
                            ComponentId = 0,
                            Name = "Incident Name",
                            Status = IncidentStatus.Fixed,
                            Visible = 1,
                            Message = "Incident Message",
                            ScheduledAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DeletedAt = null,
                            HumanStatus = "Fixed"
                        }
                    }
                }));

            var all = await mock.Object.GetAllIncidentsAsync();
            var first = await mock.Object.GetIncidentAsync(1);
            var add = await mock.Object.AddIncidentAsync(new PostIncident
            {
                ComponentId = 1,
                CreatedAt = DateTime.Now,
                ComponentStatus = ComponentStatus.Operational,
                Notify = true,
                Template = "",
                Message = "Incident Message",
                Visible = 1,
                Name = "Incident Name"
            });
            var put = await mock.Object.UpdateIncidentAsync(1,
                new PutIncident
                {
                    Name = "Incident Name",
                    ComponentId = 1,
                    Message = "Incident Content",
                    Notify = true,
                    ComponentStatus = ComponentStatus.Operational,
                    Status = IncidentStatus.Fixed,
                    Visible = 1
                });

            var client = new CachetClient("https://demo.cachethq.io");

            Assert.Equal(allIncidents[0].Name, all.Data[0].Name);
            Assert.Equal(firstIncident.Name, first.Data[0].Name);
            Assert.Equal(firstIncident.Name, add.Data[0].Name);
            Assert.Equal(firstIncident.Name, put.Data[0].Name);
        }

        [Fact]
        public async Task IncidentUpdateTests()
        {
            var timeParser = "yyyy-MM-dd HH:mm:ss";

            var allUpdates = new List<IncidentUpdate>
            {
                new IncidentUpdate
                {
                    Id = 1,
                    IncidentId = 1,
                    Status = IncidentStatus.Fixed,
                    Message = "The monkeys are back and rested!",
                    UserId = 1,
                    CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    HumanStatus = "Fixed",
                    Permalink = "http://cachet.app/incidents/1#update-1"
                },
                new IncidentUpdate
                {
                    Id = 2,
                    IncidentId = 1,
                    Status = IncidentStatus.Watching,
                    Message = "Our monkeys need a break from performing. They'll be back after a good rest.",
                    UserId = 1,
                    CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    HumanStatus = "Watching",
                    Permalink = "http://cachet.app/incidents/1#update-2"
                },
                new IncidentUpdate
                {
                    Id = 3,
                    IncidentId = 1,
                    Status = IncidentStatus.Identified,
                    Message = "We have identified the issue with our lovely performing monkeys.",
                    UserId = 1,
                    CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    HumanStatus = "Identified",
                    Permalink = "http://cachet.app/incidents/1#update-3"
                },
                new IncidentUpdate
                {
                    Id = 4,
                    IncidentId = 1,
                    Status = IncidentStatus.Watching,
                    Message = "We're actively watching this issue, so it remains unresolved.",
                    UserId = 1,
                    CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                    HumanStatus = "Watching",
                    Permalink = "http://cachet.app/incidents/1#update-4"
                },
            };
            var firstUpdate = new IncidentUpdate
            {
                Id = 1,
                IncidentId = 1,
                Status = IncidentStatus.Fixed,
                Message = "The monkeys are back and rested!",
                UserId = 1,
                CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                HumanStatus = "Fixed",
                Permalink = "http://cachet.app/incidents/1#update-1"
            };

            var mock = new Mock<ICachetClient>(MockBehavior.Strict);

            mock.Setup(x => x.GetAllUpdatesForIncidentAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResponseIncidentUpdate
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<IncidentUpdate>
                    {
                        new IncidentUpdate
                        {
                            Id = 1,
                            IncidentId = 1,
                            Status = IncidentStatus.Fixed,
                            Message = "The monkeys are back and rested!",
                            UserId = 1,
                            CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            HumanStatus = "Fixed",
                            Permalink = "http://cachet.app/incidents/1#update-1"
                        },
                        new IncidentUpdate
                        {
                            Id = 2,
                            IncidentId = 1,
                            Status = IncidentStatus.Watching,
                            Message = "Our monkeys need a break from performing. They'll be back after a good rest.",
                            UserId = 1,
                            CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            HumanStatus = "Watching",
                            Permalink = "http://cachet.app/incidents/1#update-2"
                        },
                        new IncidentUpdate
                        {
                            Id = 3,
                            IncidentId = 1,
                            Status = IncidentStatus.Identified,
                            Message = "We have identified the issue with our lovely performing monkeys.",
                            UserId = 1,
                            CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            HumanStatus = "Identified",
                            Permalink = "http://cachet.app/incidents/1#update-3"
                        },
                        new IncidentUpdate
                        {
                            Id = 4,
                            IncidentId = 1,
                            Status = IncidentStatus.Watching,
                            Message = "We're actively watching this issue, so it remains unresolved.",
                            UserId = 1,
                            CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            HumanStatus = "Watching",
                            Permalink = "http://cachet.app/incidents/1#update-4"
                        }
                    }
                }));

            mock.Setup(x => x.GetIncidentUpdateAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new ResponseIncidentUpdate
                {
                    Data = new List<IncidentUpdate>
                    {
                        new IncidentUpdate
                        {
                            Id = 1,
                            IncidentId = 1,
                            Status = IncidentStatus.Fixed,
                            Message = "The monkeys are back and rested!",
                            UserId = 1,
                            CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            HumanStatus = "Fixed",
                            Permalink = "http://cachet.app/incidents/1#update-1"
                        }
                    }
                }));

            mock.Setup(x => x.AddIncidentUpdateAsync(It.IsAny<int>(), It.IsAny<PostIncidentUpdate>()))
                .Returns(Task.FromResult(new ResponseIncidentUpdate
                {
                    Data = new List<IncidentUpdate>
                    {
                        new IncidentUpdate
                        {
                            Id = 1,
                            IncidentId = 1,
                            Status = IncidentStatus.Fixed,
                            Message = "The monkeys are back and rested!",
                            UserId = 1,
                            CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            HumanStatus = "Fixed",
                            Permalink = "http://cachet.app/incidents/1#update-1"
                        }
                    }
                }));

            mock.Setup(x => x.UpdateIncidentUpdateAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IncidentStatus>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new ResponseIncidentUpdate
                {
                    Data = new List<IncidentUpdate>
                    {
                        new IncidentUpdate
                        {
                            Id = 1,
                            IncidentId = 1,
                            Status = IncidentStatus.Fixed,
                            Message = "The monkeys are back and rested!",
                            UserId = 1,
                            CreatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2016-12-05 19:37:20", timeParser, null),
                            HumanStatus = "Fixed",
                            Permalink = "http://cachet.app/incidents/1#update-1"
                        }
                    }
                }));

            var all = await mock.Object.GetAllUpdatesForIncidentAsync(1);
            var first = await mock.Object.GetIncidentUpdateAsync(1, 1);
            var add = await mock.Object.AddIncidentUpdateAsync(1, new PostIncidentUpdate
            {
                Message = "Test",
                Status = IncidentStatus.Identified
            });
            var put = await mock.Object.UpdateIncidentUpdateAsync(1, 1, IncidentStatus.Fixed, "Fixed");

            var client = new CachetClient("https://demo.cachethq.io");

            Assert.Equal(allUpdates[0].Message, all.Data[0].Message);
            Assert.Equal(firstUpdate.Message, first.Data[0].Message);
            Assert.Equal(firstUpdate.Message, add.Data[0].Message);
            Assert.Equal(firstUpdate.Message, put.Data[0].Message);
        }

        [Fact]
        public async Task MetricTests()
        {
            var timeParser = "yyyy-MM-dd HH:mm:ss";

            var metric = new Metric
            {
                Id = 1,
                DefaultValue = 0,
                Description = "Cups of coffee consumed.",
                Suffx = "Cups",
                Name = "Coffee",
                DisplayChart = 1,
                CalcType = 1,
                CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                DefaultViewName = "Last 12 Hours"
            };
            var points = new List<MetricPoint>
            {
                new MetricPoint
                {
                    Id = 1,
                    MetricId = 1,
                    Value = 1,
                    CreatedAt = DateTime.ParseExact("2015-03-11 14:21:44", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2015-03-11 14:21:44", timeParser, null)
                },
                new MetricPoint
                {
                    Id = 2,
                    MetricId = 1,
                    Value = 3,
                    CreatedAt = DateTime.ParseExact("2015-03-11 14:22:11", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2015-03-11 14:22:11", timeParser, null)
                },
                new MetricPoint
                {
                    Id = 3,
                    MetricId = 1,
                    Value = 3,
                    CreatedAt = DateTime.ParseExact("2015-03-11 14:34:55", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2015-03-11 14:34:55", timeParser, null)
                }
            };

            var mock = new Mock<ICachetClient>(MockBehavior.Strict);

            mock.Setup(x => x.GetAllMetricsAsync())
                .Returns(Task.FromResult(new ResponseMetric
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Metric>
                    { 
                        new Metric
                        {
                            Id = 1,
                            DefaultValue = 0,
                            Description = "Cups of coffee consumed.",
                            Suffx = "Cups",
                            Name = "Coffee",
                            DisplayChart = 1,
                            CalcType = 1,
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DefaultViewName = "Last 12 Hours"
                        }
                    }
                }));

            mock.Setup(x => x.GetMetricAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResponseMetric
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Metric>
                    {
                        new Metric
                        {
                            Id = 1,
                            DefaultValue = 0,
                            Description = "Cups of coffee consumed.",
                            Suffx = "Cups",
                            Name = "Coffee",
                            DisplayChart = 1,
                            CalcType = 1,
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DefaultViewName = "Last 12 Hours"
                        }
                    }
                }));

            mock.Setup(x => x.AddMetricAsync(It.IsAny<PostMetric>()))
                .Returns(Task.FromResult(new ResponseMetric
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Metric>
                    {
                        new Metric
                        {
                            Id = 1,
                            DefaultValue = 0,
                            Description = "Cups of coffee consumed.",
                            Suffx = "Cups",
                            Name = "Coffee",
                            DisplayChart = 1,
                            CalcType = 1,
                            CreatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-08-01 12:00:00", timeParser, null),
                            DefaultViewName = "Last 12 Hours"
                        }
                    }
                }));

            mock.Setup(x => x.GetMetricPointsAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new ResponseMetricPoint
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<MetricPoint>
                    {
                        new MetricPoint
                        {
                            Id = 1,
                            MetricId = 1,
                            Value = 1,
                            CreatedAt = DateTime.ParseExact("2015-03-11 14:21:44", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-03-11 14:21:44", timeParser, null)
                        },
                        new MetricPoint
                        {
                            Id = 2,
                            MetricId = 1,
                            Value = 3,
                            CreatedAt = DateTime.ParseExact("2015-03-11 14:22:11", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-03-11 14:22:11", timeParser, null)
                        },
                        new MetricPoint
                        {
                            Id = 3,
                            MetricId = 1,
                            Value = 3,
                            CreatedAt = DateTime.ParseExact("2015-03-11 14:34:55", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-03-11 14:34:55", timeParser, null)
                        }
                    }
                }));

            mock.Setup(x => x.AddMetricPointAsync(It.IsAny<int>(), It.IsAny<PostMetricPoint>()))
                .Returns(Task.FromResult(new ResponseMetricPoint
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<MetricPoint>
                    {
                        new MetricPoint
                        {
                            Id = 1,
                            MetricId = 1,
                            Value = 1,
                            CreatedAt = DateTime.ParseExact("2015-03-11 14:21:44", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-03-11 14:21:44", timeParser, null)
                        },
                        new MetricPoint
                        {
                            Id = 2,
                            MetricId = 1,
                            Value = 3,
                            CreatedAt = DateTime.ParseExact("2015-03-11 14:22:11", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-03-11 14:22:11", timeParser, null)
                        },
                        new MetricPoint
                        {
                            Id = 3,
                            MetricId = 1,
                            Value = 3,
                            CreatedAt = DateTime.ParseExact("2015-03-11 14:34:55", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-03-11 14:34:55", timeParser, null)
                        }
                    }
                }));

            var all = await mock.Object.GetAllMetricsAsync();
            var add = await mock.Object.AddMetricAsync(new PostMetric
            {
                DefaultValue = 0,
                Description = "Cups of coffee consumed.",
                Suffx = "Cups",
                Name = "Coffee",
                DisplayChart = 1
            });
            var first = await mock.Object.GetMetricAsync(1);
            var firstpoints = await mock.Object.GetMetricPointsAsync(1);
            var update = await mock.Object.AddMetricPointAsync(1, new PostMetricPoint
            {
                Timestamp = 0,
                Value = 1
            });

            var client = new CachetClient("https://demo.cachethq.io");

            Assert.Equal(metric.Name, all.Data[0].Name);
            Assert.Equal(metric.Name, add.Data[0].Name);
            Assert.Equal(metric.Name, first.Data[0].Name);
            Assert.Equal(points[0].Value, firstpoints.Data[0].Value);
            Assert.Equal(points[0].Value, update.Data[0].Value);
        }

        [Fact]
        public async Task SubscriberTests()
        {
            var timeParser = "yyyy-MM-dd HH:mm:ss";
            var allComponents = new List<Subscriber>
            {
                new Subscriber
                {
                    Id = 1,
                    Email = "support@alt-three.com",
                    VerifyCode = "1234567890",
                    VerifiedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null),
                    CreatedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null),
                    UpdatedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null)
                }
            };
            var firstComponent = allComponents[0];

            var mock = new Mock<ICachetClient>(MockBehavior.Strict);

            mock.Setup(x => x.GetAllSubscribersAsync())
                .Returns(Task.FromResult(new ResponseSubscriber
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Subscriber>
                    {
                        new Subscriber
                        {
                            Id = 1,
                            Email = "support@alt-three.com",
                            VerifyCode = "1234567890",
                            VerifiedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null),
                            CreatedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null)
                        }
                    }
                }));

            mock.Setup(x => x.AddSubscriberAsync(It.IsAny<PostSubscriber>()))
                .Returns(Task.FromResult(new ResponseSubscriber
                {
                    Meta = new ResponseMeta
                    {
                        Pagination = new ResponsePagination
                        {
                            Total = 1,
                            Count = 1,
                            PerPage = 20,
                            CurrentPage = 1,
                            TotalPages = 1,
                            Links = new ResponsePaginationLinks
                            {
                                PreviousPage = null,
                                NextPage = null
                            }
                        }
                    },
                    Data = new List<Subscriber>
                    {
                        new Subscriber
                        {
                            Id = 1,
                            Email = "support@alt-three.com",
                            VerifyCode = "1234567890",
                            VerifiedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null),
                            CreatedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null),
                            UpdatedAt = DateTime.ParseExact("2015-07-24 14:42:24", timeParser, null)
                        }
                    }
                }));

            var all = await mock.Object.GetAllSubscribersAsync();
            var first = await mock.Object.AddSubscriberAsync(new PostSubscriber
            {
                EMail = "support@alt-three.com",
                Verify = true
            });

            var client = new CachetClient("https://demo.cachethq.io");

            Assert.Equal(allComponents[0].Email, all.Data[0].Email);
            Assert.Equal(firstComponent.Email, first.Data[0].Email);
        }
    }
}
