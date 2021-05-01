import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { environment } from 'src/environments/environment';
import { Transaction } from 'src/app/models/checkout/transaction.model';

@Injectable({
    providedIn: 'root'
})
export class TransactionService {
    baseUrl = environment.baseUrl;
    transactionUrl = "api/Transaction";

    constructor(private http: HttpClient) { }

    post(transaction: Transaction) {
        return this.http.post<Transaction>(`${this.baseUrl}/${this.transactionUrl}`, transaction);
    }

}
