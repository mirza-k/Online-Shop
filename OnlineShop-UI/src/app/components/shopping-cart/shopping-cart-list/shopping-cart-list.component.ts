import { Component, OnInit } from '@angular/core';
import { shoppingCartItem } from 'src/app/models/shopping-cart-item/shoppingCartItem.model';
import { JwtService } from 'src/app/services/jwt/jwt.service';
import { ShoppingCartItemsService } from 'src/app/services/shopping-cart-items/shopping-cart-items.service';

@Component({
  selector: 'app-shopping-cart-list',
  templateUrl: './shopping-cart-list.component.html',
  styleUrls: ['./shopping-cart-list.component.css']
})
export class ShoppingCartListComponent implements OnInit {
  shoppingCartItems!: shoppingCartItem[];
  errorMsg!: string;
  userId!: string;
  showCheckoutButton = true;

  constructor(private shoppinCartService: ShoppingCartItemsService, private jwtService: JwtService) { }

  ngOnInit(): void {

    let jwtToken: any = this.jwtService.getJwtTokenEncrypted();
    this.userId = jwtToken.UserId;

    this.shoppinCartService.onChangeQuantityValueNotification.subscribe((data: boolean) => {
      this.showCheckoutButton = data;
    })

    this.shoppinCartService.get(this.userId).subscribe((res: shoppingCartItem[]) => {
      this.shoppingCartItems = res;
    })
    if (this.shoppingCartItems == null) {
      this.errorMsg = 'Shopping cart is empty!'
    }
  }

  onItemDeleted() {
    this.shoppinCartService.get(this.userId).subscribe((res: shoppingCartItem[]) => {
      this.shoppingCartItems = res;

      //sending number of shopping cart items 
      this.shoppinCartService.newShoppingCartItemNotification.emit(res.length)
    })
  }

}
