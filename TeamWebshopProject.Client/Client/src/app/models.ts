export interface Basket {
    id: number;
    customer: Customer;
    quantity: number;
    price: number;
    created: Date;
}

export interface BasketItem {
    id: number;
    basket: Basket;
    item: Item;
    quantity: number;
}

export interface Credit {
    id: number;
    creditAmount: number;
}

export interface Customer {
    id: number;
    login: Login;
    credit: Credit;
    userName: string;
    firstName: string;
    lastName: string;
    birthDay: Date;
    addressStreet: string;
    addressNumber: number;
    addressPostCode: number;
}

export interface Delivery {
    id: number;
    order: Order;
    status: string;
}

export interface Item {
    itemType: string;
    price: number;
    discount: number;
    discription: string;
    image: string;
    tags?: Array<Tag>;
}

export interface Login {
    id: number;
    accessType: string;
    email: string;
    password: string;
}

export interface Order {
    id: number;
    customer: Customer;
    price: number;
}

export interface OrderItem {
    id: number;
    order: Order;
    item: Item;
    quantity: number;
}

export interface Tag {
    id: number;
    name: string;
}