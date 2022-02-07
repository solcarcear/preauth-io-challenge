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
export class Provider {
    static readonly normalItems = 'Normal';
    static readonly conjuredItem = 'Conjured';

    name: string;
    provide: string;

    constructor(name: string, provide: string) {
        this.name = name;
        this.provide = provide;
    }
}
export class ItemToSell extends Item {
    static readonly itemBackstageName = 'Backstage passes to a TAFKAL80ETC concert';
    static readonly itemAgedBrieName = 'Aged Brie';
    static readonly itemSulfuraName = 'Sulfuras, Hand of Ragnaros';

    provider: Provider;
    factorDegreeQuality: number;
    expired: boolean;
    degreeIsPlus: boolean;

    constructor(name: string, sellIn: number, quality: number, provider: Provider) {
        super(name, sellIn, quality);
        this.provider = provider;
        this.factorDegreeQuality = provider.name === Provider.conjuredItem ? 2 : 1;
        this.expired = sellIn - 1 < 0;
        this.degreeIsPlus =
            provider.name === ItemToSell.itemBackstageName || provider.name === ItemToSell.itemBackstageName;
    }
}

export class GildedRose {
    items: Array<ItemToSell>;

    constructor(items = [] as Array<ItemToSell>) {
        this.items = items;
    }

    updateQuality() {
        this.items.map(item => {
            const sellIn = item.sellIn;
            if (item.name === ItemToSell.itemSulfuraName) {
                return false;
            }
            if (sellIn > 0) {
                item.sellIn--;
            }

            let factorDegree = GildedRose.getFactorDegree(item);
            let qualityResult = item.quality + factorDegree;

            if (qualityResult < 0) {
                item.quality = 0;
            }
            if (qualityResult > 50) {
                item.quality = 50;
            }             
        });
        return this.items;
    }

    private static getFactorDegree(item: ItemToSell) {
        let result = item.degreeIsPlus ? 1 : -1;
        switch (item.name) {
            case ItemToSell.itemBackstageName: {
                if (item.sellIn < 11) {
                    result++;
                }
                if (item.sellIn < 6) {
                    result++;
                }
                break;
            }
        }
        if (item.expired) {
            GildedRose.degreeTwice(result);
        }
        return result * item.factorDegreeQuality;
    }

    private static degreeTwice(val: number) {
        val = val * 2;
    }

}
