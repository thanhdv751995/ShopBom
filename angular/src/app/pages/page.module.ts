import { NgModule } from '@angular/core';
import { PageRoutingModule } from './page-routing.module';
import { CustomerComponent } from './customer/customer.component';
import { ProductComponent } from './product/product.component';
import { PageComponent } from './page.component';
import { DemoNgZorroAntdModule } from '../ng-zorro.module';
import { AppModule } from '../app.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
      ProductComponent,
      CustomerComponent,
      PageComponent
  ],
  imports: [
    PageRoutingModule,
    DemoNgZorroAntdModule, FormsModule, ReactiveFormsModule
  ]
})
export class PageModule { }