import { Observable, combineLatest, merge } from "rxjs";
import { debounceTime, map, scan, tap } from "rxjs/operators";

export function createFilter<T>(filter$: Observable<string>, data$: Observable<T[]>, fieldName: string = 'nome') {
    return combineLatest([data$, filter$])
        .pipe(
            debounceTime(300),
            map(([data, valueFilter]) => {
                if (!valueFilter) return data;
                return data.filter(
                    (character: any) =>
                        character[fieldName]?.trim()?.toLowerCase()?.startsWith(valueFilter?.toLowerCase()?.trim())
                );
            })
        );
}

export function createAdd<T>(add$: Observable<T>, data$: Observable<T[]>) {
    return merge(data$, add$)
        .pipe(
            scan<any, T[]>((acc: T[], value: T) => {
                if (!acc) {
                    return Array.isArray(value) ? value : [value];
                }

                return [...acc, value];
            }),
        );
}

export function createFilterAndAdd<T>(add$: Observable<T>, filter$: Observable<string>, data$: Observable<T[]>, fieldName: string = 'nome') {
    const dataWithAdd$ = merge(data$, add$)
        .pipe(
            scan<any, T[]>((acc: T[], value: T) => value ? [...acc, value] : [...acc])
        );

    return createFilter<T>(filter$, dataWithAdd$, fieldName);
}

export function createFilterAndCRUD<T>(crud$: Observable<{ action: 'add' | 'remove', value: T }>, filter$: Observable<string>, data$: Observable<T[]>, fieldName: string = 'nome', allValues: T[] = []) {
    const dataWithCRUD$: Observable<T[]> = merge(data$, crud$)
        .pipe(
            scan<any, any>((acc: T[], value: { action: 'add' | 'remove', value: T }) => {
                if (!value) { return [...acc] }

                if (value?.action == 'add') { return value?.value ? [...acc, value?.value] : [...acc]; }

                console.log(value);

                if (value?.action == 'remove') { return acc.filter(v => v !== value.value); }

                return [...acc]
            }),
            tap(console.log),
            tap((value) => {
                allValues.length = 0;
                allValues.push(...value);
            })
        );

    return createFilter(filter$, dataWithCRUD$, fieldName);
}