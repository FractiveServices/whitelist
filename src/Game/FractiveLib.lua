-- #######################################################
-- Copyright (c) VAVE 2022. All rights reserved.
-- VAVE LICENSED SOURCE CODE
-- 
-- File: FractiveLib.lua
-- Description: Main library for the Fractive whitelisting API
-- 
-- Author: B. Sugiyama
-- Date: 2022/10/08
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
function api:isUserAuthorized(userId)		
	local data = {
		ID = userId,
		Customer = Configuration.CustomerKey.Value
	};
		
	local encoded = httpSvc:JSONEncode(data);
	
	local encodedBase64 = Base64.encode(encoded);
	
	local uri = Configuration.Server.Value.."/whitelist/"..encodedBase64;
	
	local response;
	local respData;

	pcall(function()
		response = httpSvc:GetAsync(uri);
		respData = httpSvc:JSONDecode(response);        
	end)

	if respData ~= nil then
		return respData.AllowedAccess;
	else
		return false;
	end
end

function api:isGameAuthorized()
	local ownerId;

	local creatorId = game.CreatorId;

	if game.CreatorType == Enum.CreatorType.Group then
		ownerId = game:GetService("GroupService"):GetGroupInfoAsync(creatorId).Owner.Id;
	else
		ownerId = creatorId;
	end

	return api.isUserAuthorized(api, game.CreatorId);
end

return api;

-- EOF