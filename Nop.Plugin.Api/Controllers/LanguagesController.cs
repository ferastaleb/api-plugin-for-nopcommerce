﻿using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Stores;
using Nop.Plugin.Api.Attributes;
using Nop.Plugin.Api.DTOs.Languages;
using Nop.Plugin.Api.JSON.ActionResults;
using Nop.Plugin.Api.MappingExtensions;
using Nop.Plugin.Api.Serializers;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Services.Stores;

namespace Nop.Plugin.Api.Controllers
{
    [BearerTokenAuthorize]
    public class LanguagesController : BaseApiController
    {
        private ILanguageService _languageService;

        public LanguagesController(IJsonFieldsSerializer jsonFieldsSerializer,
            IAclService aclService,
            ICustomerService customerService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            ILanguageService languageService)
            : base(jsonFieldsSerializer,
                  aclService,
                  customerService,
                  storeMappingService,
                  storeService,
                  discountService,
                  customerActivityService,
                  localizationService,
                  pictureService)
        {
            _languageService = languageService;
        }

        /// <summary>
        /// Retrieve all languages
        /// </summary>
        /// <param name="fields">Fields from the language you want your json to contain</param>
        /// <response code="200">OK</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [ResponseType(typeof(LanguagesRootObject))]
        [GetRequestsErrorInterceptorActionFilter]
        public IHttpActionResult GetAllLanguages(string fields = "")
        {
            IList<Language> allLanguages = _languageService.GetAllLanguages();

            IList<LanguageDto> languagesAsDto = allLanguages.Select(language =>
            {
                var dto = language.ToDto();

                dto.StoreIds = _storeMappingService.GetStoreMappings(language).Select(mapping => mapping.StoreId).ToList();

                return dto;

            }).ToList();

            var languagesRootObject = new LanguagesRootObject()
            {
                Languages = languagesAsDto
            };

            var json = _jsonFieldsSerializer.Serialize(languagesRootObject, fields);

            return new RawJsonActionResult(json);
        }
    }
}
