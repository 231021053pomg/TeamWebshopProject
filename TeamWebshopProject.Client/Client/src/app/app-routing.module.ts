import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ProductpageComponent } from './productpage/productpage.component';
import { CategorypageComponent } from './categorypage/categorypage.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { NewitemComponent } from './newitem/newitem.component';
import { LoginFormComponent } from './login-form/login-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/front', pathMatch: 'full' },
  { path: 'front', component: FrontpageComponent },
  { path: 'product/:id', component: ProductpageComponent },
  { path: 'category', component: CategorypageComponent },
  { path: 'admin', component: AdminpageComponent },
  { path: 'newitem', component: NewitemComponent },
  { path: 'Login', component: LoginFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
