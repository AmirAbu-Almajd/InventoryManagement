import { Routes } from "@angular/router";
import { ProductListComponent } from "../products/product-list.component";
import { PricesComponent } from "../prices/prices.component";
import { StocksComponent } from "../stocks/stocks.component";
import { SalesComponent } from "../sales/sales.component";


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
        component : PricesComponent
    },
    {
        path: 'stocks',
        component : StocksComponent
    },
    {
        path: 'sales',
        component : SalesComponent
    },
    
]