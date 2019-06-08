export class Helper {
    minFeet: number = 4;
    maxFeet: number = 7;
    heights: any[] = [];
    feets: number[] = [4, 5, 6, 7];
    inches: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    constructor() {
    }

    GetFeetWithInches() {
        let count = this.minFeet;
        let height: string;
        let feetIterator = this.GetFeet(this.feets);
        while(this.maxFeet > count ) {
            let feet = feetIterator.next();
            let inchIterator = this.GetInch(this.inches);

            for (let i = 1; i <= this.inches.length; i++){
            let inch = inchIterator.next();
            height = feet.value + 'ft ' + inch.value + 'in' + ' - ' + Math.ceil(this.GetInCms(parseFloat(feet.value + '.' + inch.value))) + 'cms';
            this.heights.push({id: count, name: height});
            }
            count++;
        }

        height = 7 + 'ft ' + this.GetInCms(7) + 'cms';

        this.heights.push({id: 7, name: height});

        return this.heights;
    }

    *GetFeet(feets: number[]): IterableIterator<number> {
        for (let i = 0; i < feets.length; i++) {
            yield feets[i];
          }
    }

    *GetInch(inches: number[]): IterableIterator<number> {
        for (let i = 0; i < this.inches.length; i++) {
            yield inches[i];
          }
    }

    GetInCms(inch: number) {
        return inch * 30;
    }
}
