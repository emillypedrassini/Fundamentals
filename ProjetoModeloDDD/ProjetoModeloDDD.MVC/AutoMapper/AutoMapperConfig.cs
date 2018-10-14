using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        //método responsável por fazer o registro dos mapeamentos
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>(); // do dominio para viewModel
                x.AddProfile<ViewModelToDomainMappingProfile>(); // da viewModel para o dominio
            });
        }
    }
}