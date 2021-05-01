import { Component, Input, OnInit } from '@angular/core';
import { BuyNowItem } from 'src/app/models/shopping-cart-item/buy-now-item.model';
import { shoppingCartItem } from 'src/app/models/shopping-cart-item/shoppingCartItem.model';

@Component({
  selector: 'app-checkout-item',
  templateUrl: './checkout-item.component.html',
  styleUrls: ['./checkout-item.component.css']
})
export class CheckoutItemComponent implements OnInit {
  @Input() item!:BuyNowItem;
  @Input() itemShoppingCart!:shoppingCartItem;

  constructor() { }

  ngOnInit(): void {
  }

}
