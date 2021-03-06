﻿namespace Nop.Plugin.Api.Constants
{
    public static class WebHookNames
    {
        public const string FiltersGetAction = "FiltersGetAction";

        public const string GetWebhookByIdAction = "GetWebHookByIdAction";

        public const string CustomerCreated = "customers/created";
        public const string CustomerUpdated = "customers/updated";
        public const string CustomerDeleted = "customers/deleted";

        public const string ProductCreated = "products/created";
        public const string ProductUpdated = "products/updated";
        public const string ProductDeleted = "products/deleted";
        public const string ProductUnmapped = "products/unmapped";

        public const string CategoryCreated = "categories/created";
        public const string CategoryUpdated = "categories/updated";
        public const string CategoryDeleted = "categories/deleted";
        public const string CategoryUnmapped = "categories/unmapped";

        public const string OrderCreated = "orders/created";
        public const string OrderUpdated = "orders/updated";
        public const string OrderDeleted = "orders/deleted";

        public const string ProductCategoryMapCreated = "product_category_map/created";
        public const string ProductCategoryMapUpdated = "product_category_map/updated";
        public const string ProductCategoryMapDeleted = "product_category_map/deleted";

        public const string StoreUpdated = "stores/updated";
    }
}
