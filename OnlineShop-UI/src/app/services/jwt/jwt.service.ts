import { JsonpClientBackend } from '@angular/common/http';
import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
    providedIn: 'root'
})
export class JwtService {

    getJwtTokenEncrypted() {
        let jwtToken = JSON.stringify(localStorage.getItem('jwtToken'));
        let encryptedJwtToken:any = this.decrypt(jwtToken);
        return encryptedJwtToken;
    }

    decrypt(token: string) {
        return jwt_decode(token);
    }
}
