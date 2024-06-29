import { test123TemplatePage } from './app.po';

describe('test123 App', function() {
  let page: test123TemplatePage;

  beforeEach(() => {
    page = new test123TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
