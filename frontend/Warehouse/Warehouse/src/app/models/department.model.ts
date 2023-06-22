export class Department {
  constructor(
    public id: number,
    public name: string,
    public products: string[],
    public workers: string[]
  ) { }
}