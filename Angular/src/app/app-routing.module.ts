import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';



const routes: Routes = [
  {path: 'Products', component:ProductsComponent},
  {path: 'Orders', component:OrdersComponent},
  {path: 'Basket', component: BasketComponent},
  {path: 'Orders/All', component: OrdersComponent},

  {path: '', redirectTo:'products', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
