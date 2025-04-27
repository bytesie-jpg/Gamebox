export class CircularQueue<T> {
    private items: T[] = [];
    private readonly buffer: number;

    constructor(items: T[]) {
        this.items = items;
        this.buffer = items.length;
    }

    public get length(): number {
        return this.items.length;
    }

    public get empty(): boolean {
        return this.items.length === 0;
    }


    private enqueueFront(item: T | undefined): void {
        if(item) this.items.unshift(item);
    }

    private enqueueBack(item: T | undefined): void {
        if (item) this.items.push(item);
    }

    public dequeueFront(): T | undefined {
        const item: T | undefined = this.items.shift();
        if (item) this.enqueueBack(item);
        return item;
    }

    public dequeueBack(): T | undefined {
        const item: T | undefined = this.items.pop();
        if (item) this.enqueueFront(item);
        return item;
    }

    public peek(): T | undefined {
        return this.items[this.items.length - 1];
    }
}