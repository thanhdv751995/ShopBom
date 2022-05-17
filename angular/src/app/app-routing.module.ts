import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CustomerComponent } from './pages/customer/customer.component';
import { PageModule } from './pages/page.module';
import { ProductComponent } from './pages/product/product.component';

const routes: Routes = [
  
  // { path: '',   redirectTo: '/page', pathMatch: 'full' },
  { path: '',  loadChildren: () => import(`./pages/page.module`).then(m => m.PageModule) },
  { path: 'login',component : LoginComponent }, 
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
