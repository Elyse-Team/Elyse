Elyse
=====

Elyse is a funny solution to learn English for kids

Requirements
-------------------

- Windows system
- Java
- [LanguageTool server running](https://languagetool.org/) [(download link)](https://languagetool.org/download/LanguageTool-2.7.zip)


Run languagetool server
-------------------


    java -cp languagetool-server.jar org.languagetool.server.HTTPServer --port 8081

*Type in your browser for testing*

[http://localhost:8081?language=en-US&text=a simple test](http://localhost:8081?language=en-US&text=a simple test)

For help check [the wiki](http://wiki.languagetool.org/http-server)
