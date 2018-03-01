# The program - EntityFrameworkDemo

Program follows the MVVM design principle and utilizes WPF for the user interface.

Main purpouse is to create random measurement data of a subframe point with x,y,z measurements or optionally read this data from a file. Datasets of 20 subframes is used as default.

The variance of datapoint for x,y,z is calculated and data is visualised with the help of WPF datagrid and OxyPlot. For data analysing, user can set tolerances invidually for x,y,z measurements. If measurement value exceeds this limit, the cell containing invalid data is highlighted by red color.

# Frameworks

Mvvm light [http://www.mvvmlight.net]
Entity FRamework Core 2.1 [https://docs.microsoft.com/en-us/ef/core/]
Unity Container [https://msdn.microsoft.com/en-us/library/ff647202.aspx]

# Authors

Antti Riksman

If debugging is the process of removing software bugs, then programming must be the process of putting them in.
