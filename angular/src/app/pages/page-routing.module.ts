import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../services/Auth/auth.guard';
import { CustomerComponent } from './customer/customer.component';
import { PageComponent } from './page.component';
import { ProductComponent } from './product/product.component';


const routes: Routes = [
    {
        path: '', component: PageComponent, canActivate:[AuthGuard],
        children: [
          //  {path: '', component: PageComponent},
            { path: 'product', component: ProductComponent, },
            { path: 'customer', component: CustomerComponent, },

        ]
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PageRoutingModule { }