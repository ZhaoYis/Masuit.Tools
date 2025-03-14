﻿using Masuit.Tools.AspNetCore.ResumeFileResults.Extensions;
using Masuit.Tools.AspNetCore.ResumeFileResults.ResumeFileResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Masuit.Tools.AspNetCore.ResumeFileResults.Executor;

/// <summary>
/// 使用本地虚拟路径的可断点续传的FileResult
/// </summary>
internal class ResumeVirtualFileResultExecutor : VirtualFileResultExecutor, IActionResultExecutor<ResumeVirtualFileResult>
{
    /// <summary>
    /// 执行FileResult
    /// </summary>
    /// <param name="context"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public virtual Task ExecuteAsync(ActionContext context, ResumeVirtualFileResult result)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (result == null)
        {
            throw new ArgumentNullException(nameof(result));
        }

        context.SetContentDispositionHeaderInline(result);

        return base.ExecuteAsync(context, result);
    }

    public ResumeVirtualFileResultExecutor(ILoggerFactory loggerFactory, IWebHostEnvironment hostingEnvironment) : base(loggerFactory, hostingEnvironment)
    {
    }
}
