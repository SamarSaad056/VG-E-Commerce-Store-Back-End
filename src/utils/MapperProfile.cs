namespace FusionTech.src.Utils
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Supply mappings
            CreateMap<Supply, SupplyReadDto>();
            CreateMap<SupplyCreateDto, Supply>();
            CreateMap<SupplyUpdateDto, Supply>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Person mappings
            CreateMap<PersonSignUpDTO, Person>();
            CreateMap<PersonSignInDTO, Person>();
            CreateMap<Person, PersonReadDto>();
            // CreateMap<PersonUpdateDto, Person>();

            //Supply
            CreateMap<Supply, SupplyReadDto>();
            CreateMap<SupplyCreateDto, Supply>();
            CreateMap<SupplyUpdateDto, Supply>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, strProperty) => strProperty != null)
                );

            // Customer mappings
            CreateMap<CustomerSignUpDTO, Customer>();
            CreateMap<Customer, CustomerReadDto>();
            // CreateMap<CustomerUpdateDto, Customer>();

            // StoreEmployee mappings
            CreateMap<StoreEmployeeSignUpDTO, StoreEmployee>();
            CreateMap<StoreEmployee, StoreEmployeeReadDto>();
            // CreateMap<StoreEmployeeUpdateDto, StoreEmployee>();

            // SystemAdmin mappings
            CreateMap<SystemAdminSignUpDTO, SystemAdmin>();
            CreateMap<SystemAdmin, SystemAdminReadDto>();
            // CreateMap<SystemAdminUpdateDto, SystemAdmin>();


            // Category mappings
            CreateMap<Category, CategoryBasicDto>();
            CreateMap<Category, CategoryDetailedDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Payment mappings
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Ordergames mappings
            CreateMap<OrderedGames, OrderedGamesReadDto>();
            CreateMap<OrderedGamesCreateDto, OrderedGames>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // order mappings
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>()
                .ForMember(
                    dest => dest.CustomerId,
                    opt => opt.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Console mappings
            CreateMap<GameConsole, ConsoleReadDTO>();
            CreateMap<ConsoleUpdateDTO, GameConsole>();
            CreateMap<ConsoleCreateDto, GameConsole>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            //inventory
            CreateMap<Inventory, InventoryReadDto>();
            CreateMap<InventoryUpdateDTO, Inventory>();
            CreateMap<InventoryCreateDto, Inventory>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            //Supply
            CreateMap<Supply, SupplyReadDto>();
            CreateMap<SupplyCreateDto, Supply>();
            CreateMap<SupplyUpdateDto, Supply>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, strProperty) => strProperty != null)
                );

            // Payment mappings
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Console mappings
            CreateMap<GameConsole, ConsoleReadDTO>();
            CreateMap<ConsoleUpdateDTO, GameConsole>();
            CreateMap<ConsoleCreateDto, GameConsole>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Studio mappings
            CreateMap<GameStudio, StudioReadDTO>();
            CreateMap<StudioUpdateDTO, GameStudio>();
            CreateMap<StudioCreateDTO, GameStudio>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Supplier mappings
            CreateMap<Supplier, SupplierReadDto>();
            CreateMap<SupplierCreateDto, Supplier>();
            CreateMap<SupplierUpdateDto, Supplier>();

            // Payment mappings
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<PaymentCreateDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Studio mappings
            CreateMap<GameStudio, StudioReadDTO>();
            CreateMap<StudioUpdateDTO, GameStudio>();
            CreateMap<StudioCreateDTO, GameStudio>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Console mappings
            CreateMap<GameConsole, ConsoleReadDTO>();
            CreateMap<ConsoleUpdateDTO, GameConsole>();
            CreateMap<ConsoleCreateDto, GameConsole>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Publisher mappings
            CreateMap<Publisher, PublisherReadDto>();
            CreateMap<PublisherUpdateDto, Publisher>();
            CreateMap<PublisherCreateDto, Publisher>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // Store mappings
            CreateMap<Store, StoreReadDto>();
            CreateMap<Store, StoreDetailedReadDto>();
            CreateMap<StoreCreateDto, Store>();
            CreateMap<StoreUpdateDto, Store>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            /*   //PlayedIn Mappings
              CreateMap<Played, ReadPlayedInDTO>();
              CreateMap<CreatePlayedInDTO, Store>();
              CreateMap<UpdatePlayedInDTO, Store>()
                  .ForAllMembers(opts =>
                      opts.Condition((src, dest, srcProperty) => srcProperty != null)
                  ); */

            /* //DevelopedBy Mappings
            CreateMap<Developed, ReadDevelopedByDTO>();
            CreateMap<CreateDevelopedByDTO, Store>();
            CreateMap<UpdateDevelopedByDTO, Store>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                ); */


            // VideoGameInfo mappings
            CreateMap<VideoGameInfo, VideoGameInfoReadDto>();
            CreateMap<VideoGameInfo, VideoGameWithVersionDto>();
            CreateMap<VideoGameInfo, VideoGameDetailedDto>();
            CreateMap<VideoGameInfoCreateDto, VideoGameInfo>();
            CreateMap<VideoGameInfoUpdateDto, VideoGameInfo>()
                .ForAllMembers(opts =>
                    opts.Condition((src, dest, srcProperty) => srcProperty != null)
                );

            // VideoGameVersion mappings
            CreateMap<VideoGameVersion, VideoGameVersionReadDto>();
            CreateMap<VideoGameVersion, VideoGameVersionSimpleReadDto>();
            CreateMap<VideoGameVersionCreateDto, VideoGameVersion>();
            CreateMap<VideoGameVersionUpdateDto, VideoGameVersion>()
                .ForAllMembers(opts =>
                    opts.Condition(
                        (src, dest, srcMember) =>
                            srcMember != null
                            && (srcMember is not Guid || (Guid)srcMember != Guid.Empty)
                    )
                );
        }
    }
}
