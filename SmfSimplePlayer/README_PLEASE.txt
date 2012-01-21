I did say please didn't I :-)

To use this player you need to put the compiled XAP somewhere on your web server.
I'm going to assume it is in a root folder called ClientBin.

You could then use it like this:

<object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="320" height="240">
  <param name="source" value="/ClientBin/SmfSimplePlayer.xap"/>
  <param name="background" value="white" />
  <param name="minRuntimeVersion" value="3.0.40818.0" />
  <param name="initParams" value="media=URL_TO_YOUR_VIDEO" />
  <param name="autoUpgrade" value="true" />
  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40818.0" style="text-decoration:none">
		  <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style:none"/>
  </a>
</object>

Here are the 'initParams' options:

media - required - a URI to your media stream/file
autoload - optional (default false) - used for progressive download only and if set to true will start downloading media immediately
ss - optional (default false) - if you are using an IIS Smooth Streaming source, set to true
buffer - optional (default 3.0) - if you are using progressive download, this is helpful to set to prevent severe stuttering on latent connections

Thanks,

Tim - http://timheuer.com/blog/