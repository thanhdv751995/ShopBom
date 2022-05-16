import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { ProductComponent } from './pages/product/product.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/product' },
  { path: 'product',component : ProductComponent },
  { path: 'login',component : LoginComponent },
  { path: 'customer',component : CustomerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
