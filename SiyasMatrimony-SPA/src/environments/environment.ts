// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api/',
  genderConfig: {
    displayKey: 'name',
    search: false,
    height: 'auto',
    placeholder: 'Select Gender',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchPlaceholder: 'Search',
    searchOnKey: 'name'
    },
  maritalConfig: {
      displayKey: 'name',
      search: false,
      height: 'auto',
      placeholder: 'Select Marital Status',
      customComparator: () => { },
      limitTo: 100,
      moreText: 'more',
      noResultsFound: 'No results found!',
      searchPlaceholder: 'Search',
      searchOnKey: 'name'
      },
  religionConfig: {
    displayKey: 'name',
    search: false,
    height: 'auto',
    placeholder: 'Select Religion',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchPlaceholder: 'Search',
    searchOnKey: 'name'
    },
  casteConfig : {
    displayKey: 'name',
    search: true,
    height: 'auto',
    placeholder: 'Select Caste',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchOnKey: 'name'
    },
  ProfileforConfig : {
    displayKey: 'name',
    search: true,
    height: 'auto',
    placeholder: 'Profile Created For',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchOnKey: 'name'
    },
  MotherTongueConfig : {
    displayKey: 'name',
    search: true,
    height: 'auto',
    placeholder: 'Enter Your Monther Tongue',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchOnKey: 'name'
    },
  StarConfig : {
    displayKey: 'name',
    search: false,
    height: 'auto',
    placeholder: 'Enter Your Star',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchOnKey: 'name'
    },
  HeightConfig : {
    displayKey: 'name',
    search: false,
    height: '10rem',
    placeholder: 'Enter Your Height',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchOnKey: 'name'
    },
  RashiConfig: {
    displayKey: 'name',
    search: false,
    height: 'auto',
    placeholder: 'Enter Your Rashi',
    customComparator: () => { },
    limitTo: 100,
    moreText: 'more',
    noResultsFound: 'No results found!',
    searchOnKey: 'name'
    },
    DoshamConfig: {
      displayKey: 'name',
      search: false,
      height: 'auto',
      placeholder: 'Dhosam/Manglik',
      customComparator: () => { },
      limitTo: 100,
      moreText: 'more',
      noResultsFound: 'No results found!',
      searchOnKey: 'name'
      },
      FamilystatusConfig:  {
        displayKey: 'name',
        search: false,
        height: 'auto',
        placeholder: 'Family Status',
        customComparator: () => { },
        limitTo: 100,
        moreText: 'more',
        noResultsFound: 'No results found!',
        searchOnKey: 'name'
        },
      FamilytypeConfig: {
        displayKey: 'name',
        search: false,
        height: 'auto',
        placeholder: 'Family Type',
        customComparator: () => { },
        limitTo: 100,
        moreText: 'more',
        noResultsFound: 'No results found!',
        searchOnKey: 'name'
        },
      FamilyValueConfig: {
        displayKey: 'name',
        search: false,
        height: 'auto',
        placeholder: 'Family Value',
        customComparator: () => { },
        limitTo: 100,
        moreText: 'more',
        noResultsFound: 'No results found!',
        searchOnKey: 'name'
        },
      CountryConfig: {
        displayKey: 'name',
        search: true,
        height: '10rem',
        placeholder: 'Country',
        customComparator: () => { },
        limitTo: 200,
        moreText: 'more',
        noResultsFound: 'No results found!',
        searchOnKey: 'name'
        },
      StateConfig: {
        displayKey: 'name',
        search: true,
        height: '10rem',
        placeholder: 'State',
        customComparator: () => { },
        limitTo: 100,
        moreText: 'more',
        noResultsFound: 'No results found!',
        searchOnKey: 'name'
        },
      CityConfig: {
        displayKey: 'name',
        search: true,
        height: '10rem',
        placeholder: 'City',
        customComparator: () => { },
        limitTo: 100,
        moreText: 'more',
        noResultsFound: 'No results found!',
        searchOnKey: 'name'
        }
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
