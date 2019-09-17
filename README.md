# Salmon King Seafood Reference App (SKS) WinForms C# .NET 3

![SKSWinForms](./Media/SKSWINFORMSNetCore3.jpg)

# About the App
Salmon King Seafood (SKS) is a reference App create to show some of the migration capabilities of the [Visual Basic Upgrade Companion](https://www.mobilize.net/visual-basic-upgrade-companion) [VBUC](https://www.mobilize.net/visual-basic-upgrade-companion) from [Mobilize.Net](https://www.mobilize.net)

This repo shows this [VBUC](https://www.mobilize.net/visual-basic-upgrade-companion) sample upgraded to [.NET Core 3](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0)

# Upgrading from VB6 to .NETCore3

.NET Core 3 is still a preview. And the current version of the VBUC does not generate code for .NET Core 3. 
However we know that .NET Core 3 is an appealing platform.
These are the steps you need to follow to upgrade the code from [SKSWinForms](https://github.com/MobilizeNet/SKSWinForms/) to .NET Core 3: 

1. Install .NET Core 3
2. Make a backup of your working code
3. Replace your `.csproj` with `SDK Style` projects:

Something like for `.exe` projects:
```xml
<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
 </PropertyGroup>
</Project>
```

And something like:
```xml
<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
  </PropertyGroup>

</Project>
```
For control libraries

4. Add the startup property

```xml
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <StartupObject>SKS.modMain</StartupObject>
  </PropertyGroup>
```
5. This application uses OLEDB to access MSACCESS. You can use OleDB on .NETCore3 but some of the drivers are architecture specific. You can download the [Microsoft Access Database Engine 2010 Redistributable](https://www.microsoft.com/en-us/download/details.aspx?id=13255) for 32 or 64. If for example you install the 32 bit version then add:

```xml
  <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
    <Prefer32Bit>true</Prefer32Bit>
    <PlatformTarget>x86</PlatformTarget>
  </PropertyGroup>
```

6. Change the packages.config references to PackageReferences. For this app:
```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.VisualBasic" Version="10.4.0-preview.18571.3" />
    <PackageReference Include="Mobilize.VBUC.Helpers.All" Version="8.1.2-rc0876" />
    <PackageReference Include="System.Data.Odbc" Version="4.5.0" />
    <PackageReference Include="System.Data.OleDb" Version="4.6.0-rc1.19456.4" />
    <PackageReference Include="System.Data.SqlClient" Version="4.6.1" />
    <PackageReference Include="UpgradeHelpers.DataGridViewCommon.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.DataGridViewFlex.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.DB.ADO.Controls.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.DB.DAO.Controls.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.DB.Essentials.Controls.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.Gui.ContainerHelper.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.Gui.Graphics.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.Gui.NetCore3" Version="8.1.2-rc0876" />
    <PackageReference Include="UpgradeHelpers.SupportHelper.NetCore3" Version="8.1.2-rc0876" />
  </ItemGroup>
```
7. An additional change is that DBProviderFactories are not fully supported (at least on some of the previews) so we added a method to register them manually. Add this:

```
            UpgradeHelpers.DB.DbProviderFactories.RegisterFactory("System.Data.OleDb", typeof(System.Data.OleDb.OleDbFactory));
```
At the start of your program.

8. For this app remember to copy the db to the output dir:
```xml
  <ItemGroup>
    <None Update="Orders.mdb">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>
```  

Now recompile and enjoy :)

# Migrated Screens

You can see some of the [migrated screens here](https://github.com/MobilizeNet/SKSWinForms/#migrated-screens) and read about [some VBUC Features used by this migration](https://github.com/MobilizeNet/SKSWinForms/#some-vbuc-features-used-by-this-migration)

