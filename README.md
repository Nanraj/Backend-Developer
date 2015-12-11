# Backend-Developer

Instructions:

1. Use script to create database (BackendDeveloper\WebApi\SQL Script\CreationArtist.sql)

2. Modify Web.config connectionstring accordingly

3. Create IIS virtual directory named test.api and point to BackendDeveloper\WebApi\WebApi folder.

4. To test for search artist -> http://test.api/api/artist/search/joh

5. To test for get releases by id -> http://test.api/api/artist/65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab/albums

6. All functionality can also be tested via UnitTest project using Studio Test Explorer
