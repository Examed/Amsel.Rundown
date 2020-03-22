//using Amsel.DTO.Rundown.Models;
//using Amsel.Framework.Database.SQL.NHibernate.Interfaces;
//using Amsel.Framework.Database.SQL.NHibernate.Sync.Tenant.Persistence;
//using Amsel.Models.Rundown.Models;
//using AutoMapper;
//using System.Collections.Generic;
//using System.Linq;
//using Amsel.Framework.Database.SQL.NHibernate.Sync.Tenant.Mapping;
//using Amsel.Framework.Database.SQL.Mapping;

//namespace Amsel.Endpoint.Rundown.Utilities.Mapping.DTO
//{
//    public class RundownDTOMap : Profile
//    {
//        public RundownDTOMap()
//        {
//            CreateMap<IList<TenantEntity>, bool>().ConvertUsing<TenantMappingExtentions.UsedByTenantEntity>();

//            #region RundownQueue
//            this.CreateEntityToGuidAndNameMap<RundownQueue, RundownQueue>();
//            CreateMap<RundownQueue, RundownQueue>().AddSharedTenant().ReverseMap().AddSharedTenant();
//            #endregion

//            #region RundownParameter
//            CreateMap<RundownParameter, RundownParameterDTO>()?.ReverseMap();
//            #endregion

//            #region RundownFunction
//            CreateMap<RundownFunction, RundownFunction>().AddSharedTenant().ReverseMap().AddSharedTenant();
//            #endregion

//            #region RundownElement
//            CreateMap<RundownElement, RundownElement>()?.ForMember(x => x.Values, y => y.ConvertUsing<RundownElementValues, RundownElement>(z => z));
//            CreateMap<RundownElement, RundownElement>()?.ForMember(x => x.Values, y => y.ConvertUsing<RundownElementValues, RundownElement>(z => z))
//                                                          ?.ForMember(x => x.Function, y => y.ConvertUsing<RundownElementFunction, RundownElement>(z => z));
//            CreateMap<RundownElement.RundownElementValue, RundownElement.ValueDTO>()?.ReverseMap();
//            #endregion

//            #region RundownSequence
//            this.CreateEntityToGuidAndNameMap<RundownSequence, RundownSequence>();
//            CreateMap<RundownSequence, RundownSequence>().AddSharedTenant().ReverseMap().AddSharedTenant();
//            #endregion

//            #region RundownSet
//            CreateMap<RundownSet, RundownSet>().ReverseMap();
//            #endregion
//        }

//        public class RundownElementValues : IValueConverter<RundownElement, IList<RundownElement.ValueDTO>>, IValueConverter<RundownElement, IList<RundownElement.RundownElementValue>>
//        {
//            #region PUBLIC METHODES
//            public IList<RundownElement.ValueDTO> Convert(RundownElement sourceMember, ResolutionContext context)
//            {
//                // Add a Value for all Edible Parameters
//                List<RundownElement.RundownElementValue> result = sourceMember.Function.Parameters
//                                                                      .Where(x => x.Editable)
//                                                                      .Select(item => new RundownElement.RundownElementValue(item, item.Value))
//                                                                      .ToList();

//                // Add existing Values
//                foreach(RundownElement.RundownElementValue item in sourceMember.Values)
//                {
//                    RundownElement.RundownElementValue value = result.FirstOrDefault(x => (x.Parameter == item.Parameter) &&
//                        (x.Parameter.Name == item.Parameter.Name));
//                    if(value != null)
//                        value.SetValue(item.Value);
//                }
//                return context.Mapper.Map<IList<RundownElement.ValueDTO>>(result);
//            }

//            /// <inheritdoc/>
//            public IList<RundownElement.RundownElementValue> Convert(RundownElement sourceMember, ResolutionContext context)
//            {
//                List<RundownElement.RundownElementValue> values = context.Mapper
//                                                                      .Map<List<RundownElement.RundownElementValue>>(sourceMember.Values);
//                values.RemoveAll(x => x.Value == null);
//                return values;
//            }
//            #endregion
//        }

//        public class RundownElementFunction : IValueConverter<RundownElement, RundownFunction>, IValueConverter<RundownElement, RundownFunction>
//        {
//            private readonly IReadOnlyRepository repository;

//            public RundownElementFunction(IReadOnlyRepository repository) => this.repository = repository;

//            #region PUBLIC METHODES
//            public RundownFunction Convert(RundownElement sourceMember, ResolutionContext context)
//            {
//                RundownFunction function = context.Mapper.Map<RundownFunction>(sourceMember.Function);
//                function.Parameters.RemoveAll(x => (x == null) || !x.Editable);
//                return function;
//            }

//            /// <inheritdoc/>
//            public RundownFunction Convert(RundownElement sourceMember, ResolutionContext context)
//            {
//                RundownElement element = repository.GetById<RundownElement>(sourceMember.Id);
//                return element.Function;
//            }
//            #endregion
//        }
//    }
//}