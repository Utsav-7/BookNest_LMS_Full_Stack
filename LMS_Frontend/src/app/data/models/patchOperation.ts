export interface IPatchOperation {
    op: 'replace' | 'add' | 'remove' | 'copy' | 'move' | 'test';
    path: string;
    value?: any;
    from?: string;
}