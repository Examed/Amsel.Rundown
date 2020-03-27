//using Amsel.DTO.Rundown.Models;
//using Amsel.Framework.Database.SQL.NHibernate.Interfaces;
//using Amsel.Framework.Database.SQL.NHibernate.Sync.TenantEntity.Persistence;
//using Amsel.Models.Rundown.Models;
//using AutoMapper;
//using System.Collections.Generic;
//using System.Linq;
//using Amsel.Framework.Database.SQL.NHibernate.Sync.TenantEntity.Mapping;
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
//            CreateMap<RundownElement, RundownElement>()?.ForMember(x => x.Values, y => y.ConvertUsing<RundownElement.RundownValues, RundownElement>(z => z));
//            CreateMap<RundownElement, RundownElement>()?.ForMember(x => x.Values, y => y.ConvertUsing<RundownElement.RundownValues, RundownElement>(z => z))
//                                                          ?.ForMember(x => x.Function, y => y.ConvertUsing<RundownElementFunction, RundownElement>(z => z));
//            CreateMap<RundownElement.RundownElement.RundownValue, RundownElement.ValueDTO>()?.ReverseMap();
//            #endregion

//            #region RundownSequence
//            this.CreateEntityToGuidAndNameMap<RundownSequence, RundownSequence>();
//            CreateMap<RundownSequence, RundownSequence>().AddSharedTenant().ReverseMap().AddSharedTenant();
//            #endregion

//            #region RundownSet
//            CreateMap<RundownSet, RundownSet>().ReverseMap();
//            #endregion
//        }

//        public class RundownElement.RundownValues : IValueConverter<RundownElement, IList<RundownElement.ValueDTO>>, IValueConverter<RundownElement, IList<RundownElement.RundownElement.RundownValue>>
//        {
//            #region PUBLIC METHODES
//            public IList<RundownElement.ValueDTO> Convert(RundownElement sourceMember, ResolutionContext context)
//            {
//                // Add a Value for all Edible Parameters
//                List<RundownElement.RundownElement.RundownValue> result = sourceMember.Function.Parameters
//                                                                      .Where(x => x.Editable)
//                                                                      .Select(item => new RundownElement.RundownElement.RundownValue(item, item.Value))
//                                                                      .ToList();

//                // Add existing Values
//                foreach(RundownElement.RundownElement.RundownValue item in sourceMember.Values)
//                {
//                    RundownElement.RundownElement.RundownValue value = result.FirstOrDefault(x => (x.Parameter == item.Parameter) &&
//                        (x.Parameter.Name == item.Parameter.Name));
//                    if(value != null)
//                        value.SetValue(item.Value);
//                }
//                return context.Mapper.Map<IList<RundownElement.ValueDTO>>(result);
//            }

//            /// <inheritdoc/>
//            public IList<RundownElement.RundownElement.RundownValue> Convert(RundownElement sourceMember, ResolutionContext context)
//            {
//                List<RundownElement.RundownElement.RundownValue> values = context.Mapper
//                                                                      .Map<List<RundownElement.RundownElement.RundownValue>>(sourceMember.Values);
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