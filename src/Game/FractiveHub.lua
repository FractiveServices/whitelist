-- #######################################################
-- Copyright (c) VAVE 2022. All rights reserved.
-- VAVE LICENSED SOURCE CODE
-- 
-- File: FractiveHub.lua
-- Description: Main library for the Fractive whitelisting API
-- 
-- Author: B. Sugiyama
-- Date: 2022/10/11
-- #######################################################
-- 

----------- SERVICE DEFINITIONS ----------- 
local httpSvc = game:GetService("HttpService");

-----------       IMPORTS       -----------
local Base64 = require(script.Parent.Base64);

-----------  CLASS DEFINITION   ----------- 
local api = {};

local Configuration = script.Parent.Configuration;

-----------      FUNCTIONS    ----------- 
function api:whitelistUser(userId)
	local data = {
		UserId = userId,
		APIKey = Configuration.CustomerKey.Value,
		IsGroup = false		
	};
	
	local encoded = httpSvc:JSONEncode(data);

	local encodedBase64 = Base64.encode(encoded);
	
	local uri = Configuration.HubUri.Value.."/WhitelistUser.ashx/"..encodedBase64;
	
	local response;
	local respData;

	pcall(function()
		response = httpSvc:GetAsync(uri);
		respData = httpSvc:JSONDecode(response);        
	end)

	if respData ~= nil then
		if respData.Status == "OK" then
			warn("FRCV: Successfully whitelisted "..userId);
		else
			error(respData.Status);
		end
	else
		error("FRCV: Response from server was invalid");
	end
end

function api:unwhitelistUser() error("Not implemented"); end

return api;

-- EOF