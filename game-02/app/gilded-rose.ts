import { ItemContext } from "./strategy"; 
export class Item {
    name: string;
    sellIn: number;
    quality: number;

    constructor(name, sellIn, quality) {
        this.name = name;
        this.sellIn = sellIn;
        this.quality = quality;
    }
}

export class GildedRose {
    items: Array<Item>;

    constructor(items = [] as Array<Item>) {
        this.items = items;
    }

    updateQuality() {
        this.items.map(item => {
            var context: ItemContext = new ItemContext(item);
            context.updateItem();
        });
        return this.items;
    }
}


