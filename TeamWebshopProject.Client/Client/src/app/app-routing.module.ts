import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ProductpageComponent } from './productpage/productpage.component';
import { CategorypageComponent } from './categorypage/categorypage.component';
import { AdminpageComponent } from './adminpage/adminpage.component';

const routes: Routes = [
  { path: '', component: FrontpageComponent },
  { path: 'product', component: ProductpageComponent },
  { path: 'category', component: CategorypageComponent },
  { path: 'admin', component: AdminpageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
