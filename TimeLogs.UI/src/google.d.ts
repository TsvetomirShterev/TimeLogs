declare module 'google' {
  export const charts: {
    load: (version: string, options: { packages: string[] }) => void;
    setOnLoadCallback: (callback: () => void) => void;
    visualization: {
      arrayToDataTable: (data: any[][]) => any;
      ChartWrapper: new (options: any) => any;
    };
  };
}
