import { Item } from "./gilded-rose";

export interface UpdateItem {
    updateItem(item: Item): void;
}

export class UpdateBackstageItem implements UpdateItem {
    public updateItem(item: Item): void {
        let { sellIn, quality } = item;
        let factorQualityEncrease = 1;
        if (sellIn > 0) {
            item.sellIn = sellIn - 1;
            if (sellIn < 11) {
                factorQualityEncrease++;
            }
            if (sellIn < 6) {
                factorQualityEncrease++;
            }
            item.quality = quality + factorQualityEncrease;
        }
        else if (sellIn === 0) {
            item.quality = 0;
        }
    }
}

export class UpdateAgedBrieItem implements UpdateItem {
    public updateItem(item: Item): void {
        let { sellIn, quality } = item;
        if (sellIn > 0) {
            item.sellIn = sellIn - 1;
            item.quality = quality + 1;
        }
        else if (sellIn === 0) {
            item.quality = quality + 2;
            if (item.quality > 50) {
                item.quality = 50;
            }
        }
    }
}

export class UpdateConjuredItem implements UpdateItem {
    public updateItem(item: Item): void {
        let { sellIn, quality } = item;
        if (sellIn > 0) {
            item.sellIn = sellIn - 1;
            item.quality = quality - (1 * 2);
        }
        else if (sellIn === 0) {
            item.quality = quality - (2 * 2);
            if (item.quality < 0) {
                item.quality = 0;
            }
        }
    }
}

export class UpdateNormalItem implements UpdateItem {
    public updateItem(item: Item): void {
        let { sellIn, quality } = item;
        if (sellIn > 0) {
            item.sellIn = sellIn - 1;
            item.quality = quality - 1;
        }
        else if (sellIn === 0) {
            item.quality = quality - 2;
            if (item.quality < 0) {
                item.quality = 0;
            }
        }
    }
}

export class UpdateSulfurasItem implements UpdateItem {
    public updateItem(item: Item): void {
        item.quality = 80;
    }
}

export class ItemContext {
    private update: UpdateItem;
    private item: Item;

    constructor(item: Item) {
        this.item = item;
        switch (item.name) {
            case 'Sulfuras, Hand of Ragnaros': {
                this.update = new UpdateSulfurasItem();
                break;
            }
            case 'Aged Brie': {
                this.update = new UpdateAgedBrieItem();
                break;
            }
            case 'Backstage passes to a TAFKAL80ETC concert': {
                this.update = new UpdateBackstageItem();
                break;
            }
            case 'Conjured': {
                this.update = new UpdateConjuredItem();
                break;
            }
            default: {
                this.update = new UpdateNormalItem();
                break;
            }
        };
    }

    public updateItem(): void {
        this.update.updateItem(this.item);
    }
}
