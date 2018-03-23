//
//  MPSTypeDefines.h
//  MOBPaySDK
//
//  Created by youzu_Max on 2017/9/5.
//  Copyright © 2017年 youzu. All rights reserved.
//

#ifndef MPSTypeDefines_h
#define MPSTypeDefines_h

/**
 支付渠道

 - MPSChannelWeChat: 微信支付
 - MPSChannelAliPay: 支付宝支付
 */
typedef NS_ENUM (NSUInteger, MPSChannel){
    
    MPSChannelAliPay = 50,
    MPSChannelWeChat = 22
};

/**
 支付回调状态

 - MPSPayStatusSuccess: 成功
 - MPSPayStatusFail: 失败
 - MPSPayStatusCancel: 用户取消
 - MPSPayStatusUnknown: 未知
 */
typedef NS_ENUM (NSUInteger, MPSPayStatus){
    
    MPSPayStatusBegin,
    MPSPayStatusSuccess,
    MPSPayStatusFail,
    MPSPayStatusCancel,
    MPSPayStatusUnknown,
};

#endif /* MPSTypeDefines_h */
