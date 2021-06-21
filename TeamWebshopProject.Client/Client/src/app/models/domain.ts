export interface Category {
  id: number;
  category_Name: string;

  products?: Array<Item>
}

export interface Item {
  id: number;
  item_Name: string;
  item_description: string;
  category_id: number;

}
