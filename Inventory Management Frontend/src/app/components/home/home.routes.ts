import { Routes } from "@angular/router";
import { ProductListComponent } from "../products/product-list.component";
import { ProductPriceListComponent } from "../prices/product-price-list.component";
import { StockRecordListComponent } from "../stocks/stock-record-list.component";
import { SalesRecordListComponent } from "../sales/sales-record-list.component";


export const routes: Routes = [
    {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full',
    },
    {
        path: 'products',
        component: ProductListComponent
    },
    {
        path: 'prices',
        component : ProductPriceListComponent
    },
    {
        path: 'stocks',
        component : StockRecordListComponent
    },
    {
        path: 'sales',
        component : SalesRecordListComponent
    },
    
]