import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { ProductpageComponent } from './productpage/productpage.component';
import { CategorypageComponent } from './categorypage/categorypage.component';
import { AdminpageComponent } from './adminpage/adminpage.component';
import { NewitemComponent } from './newitem/newitem.component';
import { BasketComponent } from './basket/basket.component';
import { TagComponent } from './tag/tag.component';
import { AllTagsComponent } from './all-tags/all-tags.component';
import { EdititemComponent } from './edititem/edititem.component';
import { CustomerComponent } from './customer/customer.component';
import { AllCustomersComponent } from './all-customers/all-customers.component';

const routes: Routes = [
  { path: '', redirectTo: '/front', pathMatch: 'full' },
  { path: 'front', component: FrontpageComponent },
  { path: 'product/:id', component: ProductpageComponent },
  { path: 'category', component: CategorypageComponent },
  { path: 'admin', component: AdminpageComponent },
  { path: 'newitem', component: NewitemComponent},
  { path: 'edititem/:id', component: EdititemComponent},
  { path: 'basket', component: BasketComponent},
  { path: 'basket/:id', component: BasketComponent},
  { path: 'newitem', component: NewitemComponent },
  { path: 'tag', component: TagComponent },
  { path: 'AllTags', component: AllTagsComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'allcustomers', component: AllCustomersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
