import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductItemComponent } from './components/product/product-item/product-item.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { ProductItemDetailsComponent } from './components/product/product-item-details/product-item-details.component';
import { ShoppingCartListComponent } from './components/shopping-cart/shopping-cart-list/shopping-cart-list.component';
import { ShoppingCartItemComponent } from './components/shopping-cart/shopping-cart-item/shopping-cart-item.component';
import { AdminProductListComponent } from './components/admin/admin-product-list/admin-product-list.component';
import { AdminProductItemComponent } from './components/admin/admin-product-item/admin-product-item.component';
import { AdminAddProductComponent } from './components/admin/admin-add-product/admin-add-product.component';

import { ProductService } from './services/product/product.service';
import { ShoppingCartItemsService } from './services/shopping-cart-items/shopping-cart-items.service';
import { CheckoutComponent } from './components/checkout/checkout/checkout.component';
import { CheckoutItemComponent } from './components/checkout/checkout-item/checkout-item.component';
import { PurchaseHistoryComponent } from './components/product/purchase-history/purchase-history.component';
import { PurchaseHistoryItemComponent } from './components/product/purchase-history-item/purchase-history-item.component';
import { ProductSearchComponent } from './components/product/product-search/product-search.component';
import { RegisterComponent } from './components/user/register/register.component';
import { LoginComponent } from './components/user/login/login.component';
import { AuthGuardUser } from './auth/auth.guard';
import { AuthAdminGuard } from './auth/auth-admin.guard';
import { AuthorizationFailedComponent } from './components/shared/authorization-failed/authorization-failed.component';

const appRoutes: Routes = [
  { path: '', component: ProductListComponent },
  { path: 'products', component: AdminProductListComponent, canActivate: [AuthAdminGuard], data: { perrmittedRole: ['Admin'] } },
  { path: 'product/:id', component: ProductItemDetailsComponent },
  { path: 'add-product', component: AdminAddProductComponent, canActivate: [AuthAdminGuard], data: { perrmittedRole: ['Admin'] } },
  { path: 'shopping-cart', component: ShoppingCartListComponent, canActivate: [AuthGuardUser] },
  { path: 'buy-now/checkout', component: CheckoutComponent, canActivate: [AuthGuardUser] },
  { path: 'shopping-cart/checkout', component: CheckoutComponent, canActivate: [AuthGuardUser] },
  { path: 'purchase-history/:id', component: PurchaseHistoryComponent, canActivate: [AuthGuardUser] },
  { path: 'product/search/:searchValue/:categoryId', component: ProductSearchComponent },
  { path: 'product/update/:id', component: AdminAddProductComponent, canActivate: [AuthAdminGuard], data: { perrmittedRole: ['Admin'] } },
  { path: 'user/register', component: RegisterComponent },
  { path: 'user/login', component: LoginComponent },
  { path: 'authorization-failed', component: AuthorizationFailedComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProductListComponent,
    ProductItemComponent,
    FooterComponent,
    ProductItemDetailsComponent,
    ShoppingCartListComponent,
    ShoppingCartItemComponent,
    AdminProductListComponent,
    AdminProductItemComponent,
    AdminAddProductComponent,
    CheckoutComponent,
    CheckoutItemComponent,
    PurchaseHistoryComponent,
    PurchaseHistoryItemComponent,
    ProductSearchComponent,
    RegisterComponent,
    LoginComponent,
    AuthorizationFailedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    NgbModule
  ],
  providers: [ProductService,
    ShoppingCartItemsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
