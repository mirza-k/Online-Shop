import { Guid } from "guid-typescript";

export class User{
    userId!:string;
    email!:string;
    password!:string;
    username!:string;

    constructor(email:string, pass:string, username:string){
        this.userId = Guid.create().toString();
        this.email = email;
        this.password = pass;
        this.username = username;
    }
}