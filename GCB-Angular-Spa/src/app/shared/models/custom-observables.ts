import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { createAdd, createFilter, createFilterAndAdd, createFilterAndCRUD } from './rxjs-operators';

export class ObservableWithFilterAndAdd<T> {
    filter$: BehaviorSubject<string>;
    add$: Subject<T>;

    filteredAndAddedStream$: Observable<T[]>;

    constructor(stream$: Observable<T[]>, fieldFilterName: string = 'nome') {
        this.filter$ = new BehaviorSubject('');
        this.add$ = new Subject();

        this.filteredAndAddedStream$ = createFilterAndAdd(this.add$, this.filter$, stream$, fieldFilterName);
    }
}


export class ObservableWithFilterAndCRUD<T> {
    filter$: BehaviorSubject<string>;
    crud$: Subject<{ action: 'add' | 'remove', value: T }>;

    filteredAndAddedStream$: Observable<T[]>;

    allValues: T[];

    constructor(stream$: Observable<T[]>, fieldFilterName: string = 'nome') {
        this.filter$ = new BehaviorSubject('');
        this.crud$ = new Subject<{ action: 'add' | 'remove', value: T }>();

        this.allValues = [];

        this.filteredAndAddedStream$ = createFilterAndCRUD(this.crud$, this.filter$, stream$, fieldFilterName, this.allValues);
    }
}

export class ObservableWithFilter<T> {
    filter$: BehaviorSubject<string>;

    filteredStream$: Observable<T[]>;

    constructor(stream$: Observable<T[]>, fieldName: string = 'nome') {
        this.filter$ = new BehaviorSubject('');

        this.filteredStream$ = createFilter(this.filter$, stream$, fieldName);
    }
}


export class ObservableWithAdd<T> {
    add$: BehaviorSubject<T>;

    addedStream$: Observable<T[]>;

    constructor(stream$: Observable<T[]>) {
        this.add$ = new BehaviorSubject(null as any);

        this.addedStream$ = createAdd(this.add$, stream$);
    }
}

export function AutoUnsub() {
    return function (constructor: any) {
        const orig = constructor.prototype.ngOnDestroy
        constructor.prototype.ngOnDestroy = function () {
            for (const prop in this) {
                const property = this[prop]
                if (typeof property.subscribe === "function") {
                    property.unsubscribe()
                }
            }
            orig.apply()
        }
    }
}
