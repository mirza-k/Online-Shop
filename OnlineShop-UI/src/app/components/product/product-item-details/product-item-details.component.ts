import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Product } from 'src/app/models/product/product.model';
import { shoppingCartItem } from 'src/app/models/shopping-cart-item/shoppingCartItem.model';
import { ShoeSize } from 'src/app/models/product/shoe-size.model';
import { ClothesSize } from 'src/app/models/product/clothes-size.model';
import { BuyNowItem } from 'src/app/models/shopping-cart-item/buy-now-item.model';

import { ProductService } from 'src/app/services/product/product.service';
import { ShoppingCartItemsService } from 'src/app/services/shopping-cart-items/shopping-cart-items.service';
import { ClothesSizeService } from 'src/app/services/product/clothes-size.service';
import { BuyNowItemService } from 'src/app/services/buy-now/buy-now.service';
import { UserService } from 'src/app/services/user/user.service';
import { MessageService } from 'src/app/services/message/messages.service';
import { JwtService } from 'src/app/services/jwt/jwt.service';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';

@Component({
  selector: 'app-product-item-details',
  templateUrl: './product-item-details.component.html',
  styleUrls: ['./product-item-details.component.css']
})
export class ProductItemDetailsComponent implements OnInit {
  productItem!: Product;
  shoeSizes!: ShoeSize[];
  clothesSizes!: ClothesSize[];

  notAllowedToChecokutMessageBuyNow: string = "";
  notAllowedToAddProductToShopCart: string = "";
  errorMessage: string = "";
  quantityValue: number = 1;
  sizeValue!: number;
  quantityValid = true;
  quantityInvalidMessage: string = '';


  constructor(private productService: ProductService, private shoppingCartService: ShoppingCartItemsService, private route: ActivatedRoute,
    private clothesSizeService: ClothesSizeService, private buyNowService: BuyNowItemService, private router: Router, private userService: UserService,
    private messageService: MessageService, private jwtService: JwtService) { }

  ngOnInit(): void {
    let productId = this.route.snapshot.params['id'];

    this.productService.getById(productId).subscribe((res: Product) => {
      this.productItem = res;

      //if prdouct category is shoes, fetch shoeSize list else fetch clothesSize
      if (this.productItem.categoryId == 1) {
        this.productService.getShoeSizes().subscribe((res: ShoeSize[]) => {
          this.shoeSizes = res;
          this.sizeValue = res[0].shoesSizeId;
        });
      }
      else
        this.clothesSizeService.get().subscribe((res: ClothesSize[]) => {
          this.clothesSizes = res;
          this.sizeValue = res[0].clothesSizeId;
        })
    })
  }

  ngOnDestroy() {
    if (localStorage.getItem('jwtToken') != null) {
      let jwtToken: any = this.jwtService.getJwtTokenEncrypted();
      let userId = jwtToken.UserId;

      let p = this.productItem;
      let item: BuyNowItem = new BuyNowItem(this.quantityValue, p.name, p.imageUrl, p.itemPrice, p.productId, userId,
        this.sizeValue, p.categoryId);

      this.buyNowService.buyNowItem = item;
    }
  }

  onBuyNow() {
    if (this.userService.userLoggedIn()) {
      this.router.navigate(['/buy-now/checkout'])
    }
    else {
      this.notAllowedToChecokutMessageBuyNow = this.messageService.nowtAllowedToCheckoutAfterBuyNow;
    }
  }

  onAddToCart() {
    if (this.userService.userLoggedIn()) {

      let jwtToken: any = this.jwtService.getJwtTokenEncrypted();
      let userId = jwtToken.UserId;

      //if category is 'shoes', than load list of shoeSizes, else list of clothesSizes
      if (this.productItem.categoryId == 1)
        var newShoppingCartItem = new shoppingCartItem(this.quantityValue, this.productItem.itemPrice, this.productItem.productId, userId,
          this.sizeValue, 0);
      else
        var newShoppingCartItem = new shoppingCartItem(this.quantityValue, this.productItem.itemPrice, this.productItem.productId, userId,
          0, this.sizeValue);

      this.shoppingCartService.post(newShoppingCartItem).subscribe((res) => {
        if (res == null)
          this.errorMessage = "Product already added into cart."
        else {
          alert('added to cart');

          this.shoppingCartService.get(userId).subscribe((res: shoppingCartItem[]) => {

            //sending number of shopping cart items 
            this.shoppingCartService.newShoppingCartItemNotification.emit(res.length)
          })

        }
      })
    }
    else {
      this.notAllowedToAddProductToShopCart = this.messageService.nowtAllowedToAddToShopCart;
    }
  }

  onQuantityChange(event: any) {
    let inputValue = event.srcElement.value;
    if (inputValue < 1) {
      this.quantityValid = false;
      this.quantityInvalidMessage = 'Cannot add quantity smaller than 1.'
    } else if (inputValue > this.productItem.stockQuantity) {
      this.quantityValid = false;
      this.quantityInvalidMessage = "Don't have that amount of product on stock."
    }
    else {
      this.quantityValid = true;
      this.quantityInvalidMessage = '';
    }
  }

}
