import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { ClothesSize } from 'src/app/models/product/clothes-size.model';
import { Product } from 'src/app/models/product/product.model';
import { ShoeSize } from 'src/app/models/product/shoe-size.model';
import { shoppingCartItem } from 'src/app/models/shopping-cart-item/shoppingCartItem.model';
import { ClothesSizeService } from 'src/app/services/product/clothes-size.service';
import { ProductService } from 'src/app/services/product/product.service';
import { ShoppingCartItemsService } from 'src/app/services/shopping-cart-items/shopping-cart-items.service';

@Component({
  selector: 'app-shopping-cart-item',
  templateUrl: './shopping-cart-item.component.html',
  styleUrls: ['./shopping-cart-item.component.css']
})
export class ShoppingCartItemComponent implements OnInit, OnDestroy {
  @Input() shoppingCartItem!: shoppingCartItem;
  @Output() itemDeleted = new EventEmitter();
  newPriceNotification: string = '';
  quantityInvalidMessage = '';

  constructor(private shoppingCartService: ShoppingCartItemsService, private productService: ProductService, private clothesSizeService: ClothesSizeService) { }

  ngOnDestroy() {
  }


  ngOnInit(): void {
    this.shoppingCartService.countingQuantityErors = [];

    //fetch product and check if the product price was changed
    this.productService.getById(this.shoppingCartItem.productId).subscribe((res: Product) => {

      //set new price
      if (res.itemPrice != this.shoppingCartItem.productPrice) {
        this.newPriceNotification = `Old price(${this.shoppingCartItem.productPrice}.00 €)`;
        this.shoppingCartItem.productPrice = res.itemPrice;
        this.shoppingCartItem.totalPrice = this.shoppingCartItem.productPrice * this.shoppingCartItem.quantity;
        this.shoppingCartService.update(this.shoppingCartItem).subscribe();
      }

      //set size property
      if (this.shoppingCartItem.clothesSizeId != 0) {
        let id = this.shoppingCartItem.clothesSizeId;
        this.clothesSizeService.getById(id).subscribe((res: ClothesSize) => {
          this.shoppingCartItem.clothesSize = res.name;
        })
      } else {
        let id = this.shoppingCartItem.shoesSizeId;
        this.productService.getShoeSizesById(id).subscribe((res: ShoeSize) => {
          this.shoppingCartItem.shoeSize = res.name;
        })
      }
    })
  }

  onRemoveFromCart(productId: string, userId: string) {
    this.shoppingCartService.delete(productId, userId).subscribe(res => {
      this.itemDeleted.emit();
    });
  }


  onQuantityChange(data: any, productId: string, userId: string) {
    let index = -1;
    this.shoppingCartService.countingQuantityErors.forEach((x, i) => {
      if (x.productId == this.shoppingCartItem.productId) {
        index = i;
      }
    })

    let newQuantity = parseInt(data.srcElement.value);
    let productStockQuantity = 0;

    this.productService.getById(this.shoppingCartItem.productId).subscribe((res: Product) => {
      productStockQuantity = res.stockQuantity;

      if (newQuantity < 1 || newQuantity > productStockQuantity) {
        this.quantityInvalidMessage = 'Invalid quantity.'

        if (index == -1) {
          this.shoppingCartService.countingQuantityErors.push({ productId: this.shoppingCartItem.productId, valid: false });
        } else {
          this.shoppingCartService.countingQuantityErors[index].valid = false;
        }

        //false means that quantityValue is not valid
        this.shoppingCartService.onChangeQuantityValueNotification.emit(false);
      }
      else {
        if (index != -1) {
          this.shoppingCartService.countingQuantityErors.splice(index, 1);
        }

        if (this.shoppingCartService.countingQuantityErors.length == 0) {
          this.shoppingCartService.onChangeQuantityValueNotification.emit(true);
        }

        this.quantityInvalidMessage = '';
        this.shoppingCartItem.quantity = newQuantity;
        this.shoppingCartItem.totalPrice = newQuantity * this.shoppingCartItem.productPrice;
        this.shoppingCartService.update(this.shoppingCartItem).subscribe();
      }
    })
  }

}
