import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ProductpageComponent } from './productpage/productpage.component';
import { CategorypageComponent } from './categorypage/categorypage.component';
import { AdminpageComponent } from './adminpage/adminpage.component';

const routes: Routes = [
  { path: 'front-componennt', component: FrontpageComponent },
  { path: 'product-component', component: ProductpageComponent },
  { path: 'category-component', component: CategorypageComponent },
  { path: 'admin-component', component: AdminpageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
