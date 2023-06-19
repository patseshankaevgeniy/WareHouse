export class Department{
  constructor(
    public id: number,
    public name: string,
    public workers: string[],
    public products: string[]
  ){}
}