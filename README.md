# n-ui

UI helper scripts.

## Usage

This package consists of extension methods to update UI elements, and a controller
framework.

Controllers are complex to setup; see the example in `test/Assets/scripts/MyController.cs`.

Notice that the list of tags to find is defined by the set of `Marker` components
on child elements in the scene which are in the child hierarchy of the object that
the controller is attached to.

See the tests in the `Editor/` folder for each class for usage examples.

## Install

From your unity project folder:

    npm init
    npm install shadowmint/unity-n-ui --save
    echo Assets/packages >> .gitignore
    echo Assets/packages.meta >> .gitignore

The package and all its dependencies will be installed in
your Assets/packages folder.

## Development

Setup and run tests:

    npm install
    npm install ..
    cd test
    npm install
    gulp

Remember that changes made to the test folder are not saved to the package
unless they are copied back into the source folder.

To reinstall the files from the src folder, run `npm install ..` again.

### Tests

All tests are wrapped in `#if ...` blocks to prevent test spam.

You can enable tests in: Player settings > Other Settings > Scripting Define Symbols

The test key for this package is: N_UI_TESTS
